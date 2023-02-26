using MvcMovie.Models;

namespace MovieProject.Repository
{
    public interface IMovieRepository
    {
        Task<List<Movie>> SelectAllMovie();
        Task<List<Movie>> GetAllSearch(string search);
        Task<bool> Insert(Movie movie);
        Task<Movie?> GetById(int id);
        Task<bool> Update(Movie movie);
        Task<bool> Delete(int id);
    }
}
