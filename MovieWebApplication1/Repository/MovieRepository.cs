using Microsoft.EntityFrameworkCore;
using MovieWebApplication1.Data;
using MovieWebApplication1.IRepository;
using MovieWebApplication1.Models;

namespace MovieWebApplication1.Repository
{
    public class MovieRepository : IMovieRepository
    {
 
        private readonly DataContext _ctx;

        public MovieRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Movie> CreateMvoe(Movie movie)
        {
            _ctx.Movies.Add(movie);
            await _ctx.SaveChangesAsync();
            return movie;
        }

        public async Task<List<Movie>> GetAll()
        {
            return await _ctx.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int movieId)
        {
            var movie = await _ctx.Movies.FirstOrDefaultAsync(h => h.MovieId == movieId);
            if (movie == null)
            {
                return null;
            }
            
            return movie;
            
        }

        public async Task<Movie> MovieDelete(int movieId)
        {
            var movie = await _ctx.Movies.FirstOrDefaultAsync(h => h.MovieId == movieId);
           
            if (movie == null)
            {
                return null;
            }
          
            _ctx.Movies.Remove(movie);
            await _ctx.SaveChangesAsync();
            return movie;

        }

        public async Task<Movie> MovieUpdate(Movie movieUpdate)
        {
            _ctx.Movies.Update(movieUpdate);
            await _ctx.SaveChangesAsync();
            return movieUpdate;
        }
    }
}
