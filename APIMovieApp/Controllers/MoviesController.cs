using APIMovieApp.Data;
using APIMovieApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MoviesService MoviesService { get; set; }
        public MoviesController(MoviesService moviesService)
        {
            MoviesService = moviesService;
        }
        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieVM movie)
        {
            MoviesService.AddMovie(movie);
            return Ok();

        }
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allMovies = MoviesService.GetAllMovies();
            return Ok(allMovies);
        }
        [HttpGet("id")]
        public IActionResult GetBookById([FromQuery] int id)
        {
            var movie = MoviesService.GetMovieById(id);
            return Ok(movie);
        }
        [HttpPut("id")]
        public IActionResult UpdateMovieById([FromQuery] int id,
        [FromBody] MovieVM movieVM)
        {
            var updatedMovie = MoviesService.UpdateMovieById(id, movieVM);
            return Ok(updatedMovie);
        }
        [HttpDelete("id")]
        public IActionResult DeleteMovie([FromQuery] int id)
        {
            MoviesService.DeleteMovie(id);
            return Ok();
        }
    }
}
