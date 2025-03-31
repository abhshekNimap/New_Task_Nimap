using MovieDetailsAPI.DTOs;
using MovieDetailsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieDetailsAPI.Interfaces
{
    public interface IMovieBookingService
    {
        Task<MovieBooking> BookMovieAsync(string userId, int movieId);
        Task<IEnumerable<MovieBooking>> GetUserBookingsAsync(string userId, int page, int pageSize);
    }
}
