using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterReservation.Data.Models;
using MovieTheaterReservation.Services.Services.AuditoriumService;
using MovieTheaterReservation.Shared.DisplayModels.Auditorium;
using System.Security.Claims;

namespace MovieTheaterReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriumController : ControllerBase
    {
        private readonly IAuditoriumService _auditoriumService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuditoriumController(IAuditoriumService auditoriumService, UserManager<ApplicationUser> userManager)
        {
            _auditoriumService = auditoriumService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAuditoriums()
        {
            var result = await _auditoriumService.GetAllAuditoriums();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddAuditorium(AuditoriumCreate auditoriumCreate)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _auditoriumService.CreateAuditorium(auditoriumCreate, userId);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAuditorium(int id)
        {
            var result = await _auditoriumService.GetAuditoriumById(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAuditorium(AuditoriumEdit auditoriumEdit)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _auditoriumService.UpdateAuditorium(auditoriumEdit, userId);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAuditorium(int id)
        {
            var result = await _auditoriumService.DeleteAuditorium(id);
            return Ok(result);
        }
    }
}
