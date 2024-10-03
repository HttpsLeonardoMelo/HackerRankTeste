using CalendarWebApi.DTO;
using CalendarWebApi.Models;
using CalendarWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalendarWebApi.Controllers
{
    [ApiController]
    [Route("api/calendar")]
    public class CalendarController : ControllerBase
    {
        private ICalendarService _service;
        private readonly ILogger<CalendarController> _logger;

        public CalendarController(ILogger<CalendarController> logger, ICalendarService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] CreateForm calendar)
		{
			return Created($"[POST] - /api/calendar", await _service.AddEvent(calendar));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] UpdateForm updateForm)
        {
            Calendar calendar = await _service.UpdateEvent(id, updateForm);

            if (calendar != null)
            {
                return Ok(calendar);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int eventId)
        {
            Calendar calendar = await _service.DeleteEvent(eventId);

			if (calendar == null)
            {
				return NotFound();
			}
            else
            {
				return Ok(calendar);
			}
        }

        [HttpGet]
		public async Task<IActionResult> GetAll()
		{
			List<Calendar> calendar = await _service.GetCalendar();

            if (calendar != null || calendar != new List<Calendar>())
            {
                return Ok(calendar);
            }
            else
            {
                return NotFound(new List<Calendar>());
            }
		}

		[HttpGet("query")]
		public async Task<IActionResult> GetAllById([FromQuery] int id)
		{
			Calendar calendar = await _service.GetCalendar(id);

			if (calendar != null)
			{
				return Ok(calendar);
			}
			else
			{
				return NotFound(new List<Calendar>());
			}
		}

		[HttpGet("queryLocation")]
		public async Task<IActionResult> GetQueryLocation([FromQuery] Query query)
		{
			List<Calendar> calendar = await _service.GetCalendar(query);

			if (calendar != null && calendar != new List<Calendar>().DefaultIfEmpty())
			{
				return Ok(calendar);
			}
			else
			{
				return NotFound(new List<Calendar>().DefaultIfEmpty());
			}
		}

		[HttpGet("queryName")]
		public async Task<IActionResult> GetQueryName([FromQuery] string name)
		{
			Calendar calendar = await _service.GetCalendar(name);

			if (calendar != null)
			{
				return Ok(calendar);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpGet("queryShort")]
		public async Task<IActionResult> GetQueryShort()
		{
			List<Calendar> calendar = await _service.GetEventsSorted();

			if (calendar != null)
			{
				return Ok(calendar);
			}
			else
			{
				return NotFound();
			}
		}
	}
}
