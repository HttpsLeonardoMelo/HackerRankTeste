using AutoMapper;
using CalendarWebApi.DataAccess;
using CalendarWebApi.DTO;
using CalendarWebApi.Models;

namespace CalendarWebApi.Services
{
    public class CalendarService : ICalendarService
	{
		private readonly IMapper _mapper;
		private readonly IRepository _repo;

		public CalendarService(IMapper mapper, IRepository repo)
		{
			_mapper = mapper;
			_repo = repo;
		}

		public async Task<Calendar> AddEvent(CreateForm calendarEvent)
        {
			return await _repo.AddEvent(_mapper.Map<Calendar>(calendarEvent));
		}

        public async Task<Calendar> DeleteEvent(int id)
        {
            Calendar calendar = await _repo.GetCalendar(id);

            return await _repo.DeleteEvent(calendar);
        }

        public async Task<List<Calendar>> GetCalendar()
        {
            return await _repo.GetCalendar();
        }

        public async Task<Calendar> GetCalendar(int id)
        {
            return await _repo.GetCalendar(id);
        }

        public async Task<Calendar> GetCalendar(string name)
        {
            return await _repo.GetCalendar(name);
        }

        public async Task<List<Calendar>> GetCalendar(Query query)
        {   
			return await _repo.GetCalendar(_mapper.Map<EventQueryModel>(query));
		}

        public async Task<List<Calendar>> GetEventsSorted()
        {
            return await _repo.GetEventsSorted();
        }

        public async Task<Calendar> UpdateEvent(int id, UpdateForm calendarEvent)
        {
            calendarEvent.Id = id;

            return await _repo.UpdateEvent(_mapper.Map<Calendar>(calendarEvent));
        }
    }
}
