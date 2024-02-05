using EventTicketBookingPlatform.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventTicketBookingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITiketService _ticketService;

        public TicketController(ITiketService ticketService)
        {
            _ticketService = ticketService;
        }
        /// Добавляет билет
        [HttpGet("AddTicket")]
        public IActionResult AddTicket(int ticketId)
        {
            _ticketService.AddTicket(ticketId);
            return Ok(ticketId);
        }
        /// Получает все билеты
        [HttpGet("GetAllTickets")]
        public IActionResult GetAllTickets()
        {
            var tickets = _ticketService.GetAllTickets();
            return Ok(tickets);



        }
        /// Получает все билеты пользователя

        [HttpGet("GetAllUserTickets")]
        public IActionResult GetAllUserSTickets()
        {
            var tickets = _ticketService.GetAllUserTickets();
            return Ok(tickets);


        }
        /// Удаляет билет
        [HttpGet("Detite")]
        public IActionResult RemoveTicket(int ticketID)
        {
          _ticketService.RemoveTicket(ticketID);
            return Ok("билет удален");

        }
    }

}
