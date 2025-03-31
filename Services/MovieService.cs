using NewMovieReleaseAPI.DTOs;
using NewMovieReleaseAPI.Interfaces;
using NewMovieReleaseAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewMovieReleaseAPI.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesAsync(int pageNumber, int pageSize)
        {
            var movies = await _movieRepository.GetMoviesAsync(pageNumber, pageSize);

            var movieDTOs = movies.Select(movie => new MovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                ReleaseDate = movie.ReleaseDate,
                Description = movie.Description
            });

            return movieDTOs;
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            if (movie == null) return null;

            return new MovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                ReleaseDate = movie.ReleaseDate,
                Description = movie.Description
            };
        }

        public async Task<MovieDTO> AddMovieAsync(MovieDTO movieDto)
        {
            var movie = new Movie
            {
                Title = movieDto.Title,
                Genre = movieDto.Genre,
                ReleaseDate = movieDto.ReleaseDate,
                Description = movieDto.Description
            };

            var addedMovie = await _movieRepository.AddMovieAsync(movie);

            // ✅ Manual Mapping from Entity to DTO
            return new MovieDTO
            {
                Id = addedMovie.Id,
                Title = addedMovie.Title,
                Genre = addedMovie.Genre,
                ReleaseDate = addedMovie.ReleaseDate,
                Description = addedMovie.Description
            };
        }

        public async Task<MovieDTO> UpdateMovieAsync(int id, MovieDTO movieDto)
        {
            var existingMovie = await _movieRepository.GetMovieByIdAsync(id);
            if (existingMovie == null) return null;

            existingMovie.Title = movieDto.Title;
            existingMovie.Genre = movieDto.Genre;
            existingMovie.ReleaseDate = movieDto.ReleaseDate;
            existingMovie.Description = movieDto.Description;

            var updatedMovie = await _movieRepository.UpdateMovieAsync(existingMovie);

            return new MovieDTO
            {
                Id = updatedMovie.Id,
                Title = updatedMovie.Title,
                Genre = updatedMovie.Genre,
                ReleaseDate = updatedMovie.ReleaseDate,
                Description = updatedMovie.Description
            };
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            return await _movieRepository.DeleteMovieAsync(id);
        }
    }
}
