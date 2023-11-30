using System;
using DadBodToGreekGod.Data;
using DadBodToGreekGod.Data.Entities;
using DadBodToGreekGod.Models.Macro;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using AutoMapper;

namespace DadBodToGreekGod.Services.Macro
{
    public class MacroService : IMacroService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly int _userId;

        public MacroService(UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager,
                            ApplicationDbContext dbContext)
        {
            var currentUser = signInManager.Context.User;
            var userIdClaim = userManager.GetUserId(currentUser);
            var hasValidId = int.TryParse(userIdClaim, out _userId);

            if(hasValidId == false)
            {
                throw new Exception("Attempted to build MacroService without Id Claim.");
            }

            _dbContext = dbContext;
        }

        // public MacroService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext, IMapper mapper)
        // {
        //     var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

        //     var value = userClaims?.FindFirst("id")?.Value;

        //     var validId = int.TryParse(value, out _userId);

        //     if (!validId)
        //         throw new Exception("Attempted to build MacroService without User Id claim.");
        //     _dbContext = dbContext;
        //     _mapper = mapper;
        // }

        public async Task<MacroDetail?> CreateMacroAsync(MacroCreate request)
        {
            MacroEntity entity = new()
            {
                Calories = request.Calories,
                Protein = request.Protein,
                Carbs = request.Carbs,
                Fats = request.Fats,
                OwnerId = _userId
            };

            _dbContext.Macros.Add(entity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            if(numberOfChanges != 1)
            {
                return null;
            }

            MacroDetail response = new()
            {
                Id = entity.Id,
                Calories = entity.Calories,
                Protein = entity.Protein,
                Carbs = entity.Carbs,
                Fats = entity.Fats

            };

            return response;
        }

        public async Task<MacroDetail?> GetMacroByIdAsync(int userId)
        {
            MacroEntity? entity = await _dbContext.Macros
                .FirstOrDefaultAsync(e => e.Id == userId && e.OwnerId == _userId);

            return entity is null ? null : new MacroDetail
            {
                Id = entity.Id,
                Calories = entity.Calories,
                Protein = entity.Protein,
                Carbs = entity.Carbs,
                Fats = entity.Fats
            };
        }



        public async Task<bool> UpdateMacroAsync(MacroUpdate request)
        {
            MacroEntity? entity = await _dbContext.Macros.FindAsync(request.Id);

            if(entity?.OwnerId != _userId)
            {
                return false;
            }

            entity.Calories = request.Calories;
            entity.Protein = request.Protein;
            entity.Carbs = request.Carbs;
            entity.Fats = request.Fats;

            int numberOfChanges = await _dbContext.SaveChangesAsync();
            
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteMacroAsync(int macroId)
        {
            var macroEntity = await _dbContext.Macros.FindAsync(macroId);

            if(macroEntity?.OwnerId != _userId)
                return false;

            _dbContext.Macros.Remove(macroEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }

    }
}