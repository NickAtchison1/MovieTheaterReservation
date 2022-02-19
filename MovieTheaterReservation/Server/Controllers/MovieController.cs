using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterReservation.Data.Models;
using MovieTheaterReservation.Services.Services.MovieService;
using MovieTheaterReservation.Shared.DisplayModels.Movie;
using System.Security.Claims;


namespace MovieTheaterReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MovieController(IMovieService movieService, UserManager<ApplicationUser> userManager)
        {
            _movieService = movieService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllMovies()
        {
            var rseult = await _movieService.GetAllMovies();
            return Ok(reult);
        }

        [HttpPost]
        public async Task<ActionResult> AddMovie(MovieCreate movieCreate)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _movieService.CreateMovie(movieCreate, userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMovie(int id)
        {
            var result = await _movieService.GetMovieById(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMovie(MovieEdit movieEdit)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _movieService.UpdateMovie(movieEdit, userId);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var result = await _movieService.DeleteMovieById(id);
            return Ok(result);
        }
    }
}
