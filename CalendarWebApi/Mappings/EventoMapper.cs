using AutoMapper;
using CalendarWebApi.DTO;
using CalendarWebApi.Models;
namespace Business.Mappings
{
    public class EventoMapper : Profile
    {
        public EventoMapper()
        {
            CreateMap<Calendar, CreateForm>()
                .ReverseMap();

			CreateMap<Calendar, UpdateForm>()
				.ReverseMap();

			CreateMap<Query, EventQueryModel>()
				.ReverseMap();
		}
    }
}
