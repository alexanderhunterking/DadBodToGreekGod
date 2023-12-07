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
                UserId = entity.UserId,
                Calories = entity.Calories,
                Protein = entity.Protein,
                Carbs = entity.Carbs,
                Fats = entity.Fats
            };

            return response;
        }


        public async Task<IEnumerable<MacroDetail>> GetMacroByIdAsync()
        {
            List<MacroDetail> macros = await _dbContext.Macros
             .Where(e => e.UserId == _userId)
             .Select(e => new MacroDetail
             {
                 UserId = _userId,
                 Calories = e.Calories,
                 Protein = e.Protein,
                 Carbs = e.Carbs,
                 Fats = e.Fats
             })
             .ToListAsync();

            return macros;
        }

        public async Task<bool> UpdateMacroAsync(MacroUpdate request, int userId)
        {
            MacroEntity? entity = await _dbContext.Macros
                .Where(m => m.UserId == userId)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                // MacroEntity not found for the given user
                return false;
            }

            entity.Calories = request.Calories;
            entity.Protein = request.Protein;
            entity.Carbs = request.Carbs;
            entity.Fats = request.Fats;

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