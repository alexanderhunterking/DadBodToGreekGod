using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.Calendar;

namespace DadBodToGreekGod.Services.Calendar
{
    public interface ICalendarService
    {
        Task<int> CreateCalendarAsync(CreateCalendarModel createModel);

        Task<CalendarDetailsModel> GetCalendarDetailsAsync(int calendarId);

        Task<List<CalendarListItemModel>> GetUserCalendarsAsync(int userId);

        Task UpdateCalendarAsync(int calendarId, UpdateCalendarModel updateModel);

        Task DeleteCalendarAsync(int calendarId);
    }
}