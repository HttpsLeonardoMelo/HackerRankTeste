﻿using CalendarWebApi.Models;

namespace CalendarWebApi.DataAccess
{
    public interface IRepository
    {
        Task<List<Calendar>> GetCalendar();
        Task<Calendar> GetCalendar(int id);
        Task<Calendar> AddEvent(Calendar calendarEvent);
        Task<List<Calendar>> GetCalendar(EventQueryModel query);
        Task<Calendar> DeleteEvent(Calendar calendarEvent);
        Task<List<Calendar>> GetEventsSorted();
        Task<Calendar> UpdateEvent(Calendar calendarEvent);
        Task<Calendar> GetCalendar(string name);

	}
}