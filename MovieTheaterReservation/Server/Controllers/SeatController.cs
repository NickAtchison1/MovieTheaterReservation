using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterReservation.Data.Models;
using MovieTheaterReservation.Services.Services.SeatService;
using MovieTheaterReservation.Shared.DisplayModels.Seat;
using System.Security.Claims;

namespace MovieTheaterReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeatController(ISeatService seatService, UserManager<ApplicationUser> userManager)
        {
            _seatService = seatService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSeats()
        {
            var result = await _seatService.GetSeats();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddSeat(SeatCreate seat)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _seatService.CreateSeat(seat, userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSeat(int id)
        {
            var result = await _seatService.GetSeatById(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMovie(SeatEdit seat)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _seatService.UpdateSeat(seat, userId);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteSeat(int id)
        {
            var result = await _seatService.DeleteSeat(id);
            return Ok(result);
        }
    }
}
