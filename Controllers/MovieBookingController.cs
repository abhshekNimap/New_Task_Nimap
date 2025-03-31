using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDetailsAPI.Interfaces;
using MovieDetailsAPI.Services;
using System.Security.Claims;

namespace MovieDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieBookingController : ControllerBase
    {
        private readonly IMovieBookingService _context;

        public MovieBookingController(IMovieBookingService context)
        {
            _context = context;
        }

        [HttpPost("book/{movieId}")]
        public async Task<IActionResult> BookMovie(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User is not authenticated.");

            var booking = await _context.BookMovieAsync(userId, movieId);

            if (booking == null)
                return NotFound("Movie not found or booking failed.");

            return Ok(booking);
        }

        [HttpGet("my-bookings")]
        public async Task<IActionResult> GetUserBookings([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User is not authenticated.");

            var bookings = await _context.GetUserBookingsAsync(userId, page, pageSize);

            return Ok(bookings);
        }
    }
}
