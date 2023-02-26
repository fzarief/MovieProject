using MvcMovie.Models;

namespace MovieProject.Service
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAll();
        Task<List<Movie>> GetAllSearch(string search);
        Task<bool> Insert(Movie movie);
        Task<Movie> GetById(int id);
        Task<bool> Update(Movie movie);
        Task<bool> Delete(int id);
    }
}
