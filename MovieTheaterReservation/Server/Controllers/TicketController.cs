using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterReservation.Data.Models;
using MovieTheaterReservation.Services.Services.TicketService;
using MovieTheaterReservation.Shared.DisplayModels.Ticket;
using System.Security.Claims;

namespace MovieTheaterReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly UserManager<ApplicationUser> _userManager;

        public TicketController(ITicketService ticketService, UserManager<ApplicationUser> userManager)
        {
            _ticketService = ticketService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTickets()
        {
            var result = await _ticketService.GetAllTickets();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddTicket(TicketCreate ticketCreate)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _ticketService.CreateTicket(ticketCreate, userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTicket(int id)
        {
            var result = await _ticketService.GetTicket(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTicket(TicketEdit ticketEdit)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _ticketService.UpdateTicket(ticketEdit, userId);
            return Ok(result);
        }

        public async Task<ActionResult> DeleteTicket(int id)
        {
            var result = await _ticketService.DeleteTicket(id);
            return Ok(result);
        }
    }
}
