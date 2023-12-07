using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data;
using DadBodToGreekGod.Data.Entities;
using DadBodToGreekGod.Models.Calendar;
using DadBodToGreekGod.Models.Meal;
using DadBodToGreekGod.Models.ShoppingList;
using DadBodToGreekGod.Models.UserMealAssignment;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DadBodToGreekGod.Services.Calendar
{
public class CalendarWeekService : ICalendarWeekService
{
    private readonly ApplicationDbContext _context;

    private readonly int _userId;

    public CalendarWeekService(UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager,
                            ApplicationDbContext context)
    {   
         var currentUser = signInManager.Context.User;
            var userIdClaim = userManager.GetUserId(currentUser);
            var hasValidId = int.TryParse(userIdClaim, out _userId);

            if (hasValidId == false)
            {
                throw new Exception("Attempted to build CalendarWeekService without Id Claim.");
            }

        _context = context;
    }

    public async Task<IEnumerable<CalendarWeekDetailModel>> GetCalendarWeekDetailsAsync()
    {
        List<CalendarWeekDetailModel> calendarWeeks = await _context.CalendarWeeks
            .Where(e => e.UserId == _userId)
            .Select(e => new CalendarWeekDetailModel
            {
            CalendarId = e.CalendarId,
            UserId = e.UserId,
            ShoppingDay = e.ShoppingDay,
            CookingDay = e.CookingDay
            })
            .ToListAsync();

        return calendarWeeks;
    }

    public async Task<CalendarWeekDetailModel> CreateCalendarWeekAsync(CalendarWeekCreateModel createModel)
    {
         var existingCalendarWeek = await _context.CalendarWeeks
                .FirstOrDefaultAsync(m => m.UserId == _userId);

            if (existingCalendarWeek != null)
            {
                return null;
            }
        // Example:
        CalendarWeekEntity calendarWeekEntity = new()
        {
            UserId = _userId,
            ShoppingDay = createModel.ShoppingDay,
            CookingDay = createModel.CookingDay,
            // Map other properties as needed
        };

        _context.CalendarWeeks.Add(calendarWeekEntity);
        var numberOfChanges = await _context.SaveChangesAsync();

        if (numberOfChanges != 1)
        {
            return null;
        }

        CalendarWeekDetailModel response = new() 
        {
            UserId = _userId,
            ShoppingDay = calendarWeekEntity.ShoppingDay,
            CookingDay = calendarWeekEntity.CookingDay,
        };


        return response;
    }


    public async Task<bool> UpdateCalendarWeekAsync(CalendarWeekUpdateModel updateModel, int userId)
    {
        CalendarWeekEntity? entity = await _context.CalendarWeeks
                .Where(m => m.UserId == userId)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                // MacroEntity not found for the given user
                return false;
            }

            entity.ShoppingDay = updateModel.ShoppingDay;
            entity.CookingDay = updateModel.CookingDay;

            int numberOfChanges = await _context.SaveChangesAsync();

            // Check if exactly one change was made
            return numberOfChanges == 1;
    }

    public async Task DeleteCalendarWeekAsync(int calendarId)
    {
        // Implement logic to delete the CalendarWeek and associated CalendarDays

        // Example:
        var calendarWeekEntity = await _context.CalendarWeeks
            .Include(cw => cw.CalendarDays)
            .FirstOrDefaultAsync(cw => cw.CalendarId == calendarId);

        if (calendarWeekEntity == null)
        {
            // Handle not found
            return;
        }

        _context.CalendarWeeks.Remove(calendarWeekEntity);
        await _context.SaveChangesAsync();
    }
}
}