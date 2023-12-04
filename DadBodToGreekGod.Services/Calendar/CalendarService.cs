using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Data;
using DadBodToGreekGod.Data.Entities;
using DadBodToGreekGod.Models.Calendar;
using DadBodToGreekGod.Models.Meal;
using DadBodToGreekGod.Models.ShoppingList;
using Microsoft.EntityFrameworkCore;

namespace DadBodToGreekGod.Services.Calendar
{
    public class CalendarService : ICalendarService
    {
        private readonly ApplicationDbContext _context;

        public CalendarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCalendarAsync(CreateCalendarModel createModel)
        {
            var calendarEntity = new CalendarEntity
            {
                UserId = createModel.UserId,
                ShoppingDay = createModel.ShoppingDay,
                CookingDay = createModel.CookingDay
                // Add other properties as needed
            };

            _context.Calendars.Add(calendarEntity);
            await _context.SaveChangesAsync();

            return calendarEntity.CalendarId;
        }

        public async Task<CalendarDetailsModel> GetCalendarDetailsAsync(int calendarId)
        {
            var calendarEntity = await _context.Calendars
                .Include(c => c.Meals)
                .Include(c => c.ShoppingLists)
                .FirstOrDefaultAsync(c => c.CalendarId == calendarId);

            if (calendarEntity == null)
            {
                // Handle not found
                return null;
            }

            var calendarDetails = new CalendarDetailsModel
            {
                // Other properties...

                Meals = calendarEntity.Meals.Select(m => new MealListItemModel
                {
                    MealId = m.MealId,
                    MealName = m.MealName
                    // Add other meal properties as needed
                }).ToList(),
                ShoppingLists = calendarEntity.ShoppingLists.ToList()  // Corrected line
            };

            return calendarDetails;
        }

        public async Task<List<CalendarListItemModel>> GetUserCalendarsAsync(int userId)
        {
            var userCalendars = await _context.Calendars
                .Where(c => c.UserId == userId)
                .Select(c => new CalendarListItemModel
                {
                    CalendarId = c.CalendarId,
                    UserId = c.UserId,
                    ShoppingDay = c.ShoppingDay,
                    CookingDay = c.CookingDay
                    // Add other properties as needed
                })
                .ToListAsync();

            return userCalendars;
        }

        public async Task UpdateCalendarAsync(int calendarId, UpdateCalendarModel updateModel)
        {
            var calendarEntity = await _context.Calendars.FindAsync(calendarId);

            if (calendarEntity == null)
            {
                // Handle not found
                return;
            }

            calendarEntity.ShoppingDay = updateModel.ShoppingDay;
            calendarEntity.CookingDay = updateModel.CookingDay;
            // Update other properties as needed

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCalendarAsync(int calendarId)
        {
            var calendarEntity = await _context.Calendars.FindAsync(calendarId);

            if (calendarEntity == null)
            {
                // Handle not found
                return;
            }

            _context.Calendars.Remove(calendarEntity);
            await _context.SaveChangesAsync();
        }
    }
}