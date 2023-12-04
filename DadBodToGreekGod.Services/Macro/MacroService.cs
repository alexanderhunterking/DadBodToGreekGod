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

            if (hasValidId == false)
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

        // public async Task<MacroDetail?> CreateMacroAsync(MacroCreate request)
        // {
        //     MacroEntity entity = new()
        //     {
        //         Calories = request.Calories,
        //         Protein = request.Protein,
        //         Carbs = request.Carbs,
        //         Fats = request.Fats,
        //         UserId = _userId
        //     };

        //     _dbContext.Macros.Add(entity);
        //     var numberOfChanges = await _dbContext.SaveChangesAsync();

        //     if(numberOfChanges != 1)
        //     {
        //         return null;
        //     }

        //     MacroDetail response = new()
        //     {
        //         Id = entity.Id,
        //         Calories = entity.Calories,
        //         Protein = entity.Protein,
        //         Carbs = entity.Carbs,
        //         Fats = entity.Fats

        //     };

        //     return response;
        // }

        public async Task<MacroDetail?> CreateMacroAsync(MacroCreate request)
        {
            // Check if the user has already created a MacroEntity
            var existingMacro = await _dbContext.Macros
                .FirstOrDefaultAsync(m => m.UserId == _userId);

            if (existingMacro != null)
            {
                // User has already created a MacroEntity, handle accordingly (e.g., return null, throw an exception)
                return null;
            }

            // Proceed with creating a new MacroEntity
            MacroEntity entity = new()
            {
                Calories = request.Calories,
                Protein = request.Protein,
                Carbs = request.Carbs,
                Fats = request.Fats,
                UserId = _userId
            };

            _dbContext.Macros.Add(entity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            if (numberOfChanges != 1)
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
                .FirstOrDefaultAsync(e => e.Id == userId && e.UserId == _userId);

            return entity is null ? null : new MacroDetail
            {
                Id = entity.Id,
                Calories = entity.Calories,
                Protein = entity.Protein,
                Carbs = entity.Carbs,
                Fats = entity.Fats
            };
        }



        // public async Task<bool> UpdateMacroAsync(MacroUpdate request)
        // {
        //     // Find the entity based on UserId
        //     MacroEntity? entity = await _dbContext.Macros
        //         .Where(m => m.UserId == _userId && m.Id == request.UserId)
        //         .FirstOrDefaultAsync();

        //     if (entity == null)
        //     {
        //         // Entity not found or userId doesn't match
        //         return false;
        //     }

        //     // Update the properties
        //     entity.Calories = request.Calories;
        //     entity.Protein = request.Protein;
        //     entity.Carbs = request.Carbs;
        //     entity.Fats = request.Fats;

        //     // Save changes
        //     int numberOfChanges = await _dbContext.SaveChangesAsync();

        //     // Check if exactly one change was made
        //     return numberOfChanges == 1;
        // }
       public async Task<bool> UpdateMacroAsync(MacroUpdate request, int userId)
    {
        // Your existing logic to find and update the MacroEntity for the given userId
        MacroEntity? entity = await _dbContext.Macros
            .Where(m => m.UserId == userId)
            .FirstOrDefaultAsync();

        if (entity == null)
        {
            // MacroEntity not found for the given user
            return false;
        }

        // Update the properties
        entity.Calories = request.Calories;
        entity.Protein = request.Protein;
        entity.Carbs = request.Carbs;
        entity.Fats = request.Fats;

        // Save changes
        int numberOfChanges = await _dbContext.SaveChangesAsync();

        // Check if exactly one change was made
        return numberOfChanges == 1;
    }
        public async Task<bool> DeleteMacroAsync(int macroId)
        {
            var macroEntity = await _dbContext.Macros.FindAsync(macroId);

            if (macroEntity?.UserId != _userId)
                return false;

            _dbContext.Macros.Remove(macroEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }

    }
}