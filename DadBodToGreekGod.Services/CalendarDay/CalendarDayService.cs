using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data;
using DadBodToGreekGod.Data.Entities; 
using DadBodToGreekGod.Models.UserMealAssignment;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DadBodToGreekGod.Services.UserMealAssignment
{
    
public class CalendarDayService : ICalendarDayService
{
    private readonly ApplicationDbContext _context;

    private readonly int _userId;

    public CalendarDayService(UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager,
        ApplicationDbContext context)
    {   
        var currentUser = signInManager.Context.User;
            var userIdClaim = userManager.GetUserId(currentUser);
            var hasValidId = int.TryParse(userIdClaim, out _userId);

            if (hasValidId == false)
            {
                throw new Exception("Attempted to build CalendarDayService without Id Claim.");
            }
        _context = context;
    }

    public async Task<IEnumerable<CalendarDayDetailModel?>> GetCalendarDayDetailsAsync()
    {
        List<CalendarDayDetailModel> calendarDays = await _context.CalendarDays
            .Where(e => e.UserId == _userId)
            .Select(e => new CalendarDayDetailModel
        {
            CalendarDayId = e.CalendarDayId,
            UserId = _userId,
            MealId = e.MealId,
            TimeOfDay = e.TimeOfDay,
            DayOfTheWeek = e.DayOfTheWeek
            // Add other properties as needed
        })
        .ToListAsync();

        return calendarDays;
    }

    public async Task<CalendarDayDetailModel> CreateCalendarDayAsync(CalendarDayCreateModel createModel)
    {

        CalendarDayEntity calendarDayEntity = new()
        {
            UserId = _userId,
            MealId = createModel.MealId,
            TimeOfDay = createModel.TimeOfDay,
            DayOfTheWeek = createModel.DayOfTheWeek
            // Add other properties as needed
        };

        _context.CalendarDays.Add(calendarDayEntity);
        await _context.SaveChangesAsync();

        CalendarDayDetailModel response = new()
        {
            UserId = _userId,
            MealId = calendarDayEntity.MealId,
            TimeOfDay = calendarDayEntity.TimeOfDay,
            DayOfTheWeek = calendarDayEntity.DayOfTheWeek
        };

        return response;
    }

    public async Task UpdateCalendarDayAsync(int calendarDayId, CalendarDayUpdateModel updateModel)
    {
        var calendarDayEntity = await _context.CalendarDays.FindAsync(calendarDayId);

        if (calendarDayEntity == null)
        {
            // Handle not found
            return;
        }

        calendarDayEntity.MealId = updateModel.MealId;
        calendarDayEntity.TimeOfDay = updateModel.TimeOfDay;
        calendarDayEntity.DayOfTheWeek = updateModel.DayOfTheWeek;
        // Update other properties as needed

        await _context.SaveChangesAsync();
    }

    public async Task DeleteCalendarDayAsync(int calendarDayId)
    {
        var calendarDayEntity = await _context.CalendarDays.FindAsync(calendarDayId);

        if (calendarDayEntity == null)
        {
            // Handle not found
            return;
        }

        _context.CalendarDays.Remove(calendarDayEntity);
        await _context.SaveChangesAsync();
    }
}
}