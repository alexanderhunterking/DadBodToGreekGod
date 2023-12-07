using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.Calendar;

namespace DadBodToGreekGod.Services.Calendar
{
    public interface ICalendarWeekService
    {
        Task<IEnumerable<CalendarWeekDetailModel>> GetCalendarWeekDetailsAsync();

        Task<CalendarWeekDetailModel> CreateCalendarWeekAsync(CalendarWeekCreateModel createModel);


       Task<bool> UpdateCalendarWeekAsync(CalendarWeekUpdateModel updateModel, int userId);

        Task DeleteCalendarWeekAsync(int calendarId); 
    }
}