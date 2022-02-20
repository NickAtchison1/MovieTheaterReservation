using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterReservation.Data.Models;
using MovieTheaterReservation.Services.Services.ReservationService;
using MovieTheaterReservation.Shared.DisplayModels.Reservation;
using System.Security.Claims;

namespace MovieTheaterReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservationController(IReservationService reservationService, UserManager<ApplicationUser> userManager)
        {
            _reservationService = reservationService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllReservations()
        {
            var result = await _reservationService.GetAllReservations();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddReservation(ReservationCreate reservationCreate)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _reservationService.CreateReservation(reservationCreate, userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetReservation(int id)
        {
            var result = await _reservationService.GetReservation(id);
            return Ok(result);
        }
            
        [HttpPut]
        public async Task<ActionResult> UpdateReservation(ReservationEdit reservationEdit)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _reservationService.UpdateReservation(reservationEdit, userId);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            var result = await _reservationService.DeleteReservation(id);
            return Ok(result);
        }
    }
}
