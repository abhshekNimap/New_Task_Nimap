
using MovieDetailsAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingMoviesAPI.Interfaces
{
    public interface IMovieBookingRepository
    {
        Task<MovieBookingDTO> BookMovieAsync(string userId, int movieId);
        Task<IEnumerable<MovieBookingDTO>> GetUserBookingsAsync(string userId, int page, int pageSize);
    }
}
