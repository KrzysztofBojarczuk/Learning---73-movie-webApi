using MovieWebApplication1.Models;

namespace MovieWebApplication1.IRepository
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAll();
        Task<Movie> CreateMvoe(Movie movie);
        Task<Movie> GetMovieById(int id);
        Task<Movie> MovieUpdate(Movie movieUpdate);
        Task<Movie> MovieDelete(int id);
        
    }
}
