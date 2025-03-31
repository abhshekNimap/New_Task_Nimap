using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewMovieReleaseAPI.DTOs;
using NewMovieReleaseAPI.Services;

namespace NewMovieReleaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetAllMovies")]
        public async Task<IActionResult> GetAllMovies(int pageNumber = 1, int pageSize = 10)
        {
            var movies = await _movieService.GetMoviesAsync(pageNumber, pageSize);
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
                return NotFound("Movie not found.");

            return Ok(movie);
        }

        [HttpPost("AddMovie")]
        public async Task<IActionResult> AddMovie([FromBody] MovieDTO movieDto)
        {
            if (movieDto == null)
                return BadRequest("Invalid movie data.");

            var createdMovie = await _movieService.AddMovieAsync(movieDto);
            return CreatedAtAction(nameof(GetMovieById), new { id = createdMovie.Id }, createdMovie);
        }

        [HttpPut("UpdateMovie/{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieDTO movieDto)
        {
            if (movieDto == null)
                return BadRequest("Invalid movie data.");

            var updatedMovie = await _movieService.UpdateMovieAsync(id, movieDto);
            if (updatedMovie == null)
                return NotFound("Movie not found.");

            return Ok(updatedMovie);
        }

        [HttpDelete("DeleteMovie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var isDeleted = await _movieService.DeleteMovieAsync(id);
            if (!isDeleted)
                return NotFound("Movie not found.");

            return Ok("Movie deleted successfully.");
        }
    }
}
