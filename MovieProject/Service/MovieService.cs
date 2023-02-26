using MovieProject.Repository;
using MvcMovie.Models;
using System.Threading.Tasks;

namespace MovieProject.Service
{
    public class MovieService : IMovieService
    {

        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository) { 
        _movieRepository = movieRepository;
        }
        public async Task<List<Movie>> GetAll()
        {
            return await _movieRepository.SelectAllMovie();
        }

        public async Task<bool> Insert(Movie movie)
        {
            return await _movieRepository.Insert(movie);
        }

        public async Task<Movie?> GetById(int id)
        {
            return await _movieRepository.GetById(id);

        }

        public async Task<bool> Update(Movie movie)
        {
            return await _movieRepository.Update(movie);
        }

        public async Task<bool> Delete(int id)
        {
            return await _movieRepository.Delete(id);
        }

        public async Task<List<Movie>> GetAllSearch(string search)
        {
            return await _movieRepository.GetAllSearch(search);
        }
    }
}
