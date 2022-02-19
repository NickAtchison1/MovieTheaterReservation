using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterReservation.Data.Models;
using MovieTheaterReservation.Services.Services.MovieShowingService;
using MovieTheaterReservation.Shared.DisplayModels.MovieShowing;
using System.Security.Claims;

namespace MovieTheaterReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieShowingControllerController : ControllerBase
    {
        private readonly IMovieShowingService _movieShowingService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MovieShowingControllerController(IMovieShowingService movieShowingService, UserManager<ApplicationUser> userManager)
        {
            _movieShowingService = movieShowingService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllMovieShowings()
        {
            var result = _movieShowingService.GetAllMovieShowing();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddMovieShowing(MovieShowingCreate movieShowingCreate)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _movieShowingService.CreateMovieShowing(movieShowingCreate, userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMovieShowing(int id)
        {
            var result  = _movieShowingService.GetMovieShowing(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMovieShowing(MovieShowingEdit movieShowingEdit)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _movieShowingService.UpdateMovieShowing(movieShowingEdit, userId);
            return Ok(result);
                

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteMovieShowing(int id)
        {
            var result = _movieShowingService.DeleteMovieShowing(id);
            return Ok(result);
        }
    }
}
