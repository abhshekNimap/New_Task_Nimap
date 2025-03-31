using Microsoft.EntityFrameworkCore;
using NewMovieReleaseAPI.Data;
using NewMovieReleaseAPI.Interfaces;
using NewMovieReleaseAPI.Models;

namespace NewMovieReleaseAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return false;

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync(int pageNumber, int pageSize)
        {
            return await _context.Movies
                .OrderBy(m => m.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Movie> UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
