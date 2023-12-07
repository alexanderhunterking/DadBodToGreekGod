using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadBodToGreekGod.Models.UserMealAssignment;

namespace DadBodToGreekGod.Services.UserMealAssignment
{
    public interface ICalendarDayService
    {
    Task<IEnumerable<CalendarDayDetailModel?>> GetCalendarDayDetailsAsync();
    Task<CalendarDayDetailModel> CreateCalendarDayAsync(CalendarDayCreateModel createModel);
    Task UpdateCalendarDayAsync(int calendarDayId, CalendarDayUpdateModel updateModel);
    Task DeleteCalendarDayAsync(int calendarDayId);
    }
}