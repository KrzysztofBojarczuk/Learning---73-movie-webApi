using Microsoft.EntityFrameworkCore;
using MovieWebApplication1.Data;
using MovieWebApplication1.IRepository;
using MovieWebApplication1.Models;

namespace MovieWebApplication1.Repository
{
    public class ActorRepository : IActorRepository
    {
        public DataContext _ctx;

        public ActorRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Actor> CreateActor(int movieId, Actor actor)
        {
            var movie = await _ctx.Movies.Include(h => h.Actors).FirstOrDefaultAsync(h => h.MovieId == movieId);
            movie.Actors.Add(actor);
            await _ctx.SaveChangesAsync();
            return actor;
        }

        public async Task<Actor> DeleteActor(int movieId, int actorId)
        {
            var actor = await _ctx.Acotrs.FirstOrDefaultAsync(x => x.ActorId == actorId && x.MovieId == movieId);

            if (actor == null)
            {
                return null;
            }
            _ctx.Acotrs.Remove(actor);
            _ctx.SaveChangesAsync();
            return actor;
        }

        public async Task<Actor> GetActor(int movieId, int actorId)
        {
            var actor = await _ctx.Acotrs.FirstOrDefaultAsync(r => r.ActorId == actorId && r.MovieId == movieId);

            if (actor == null)
            {
                return null;
            }
            return actor;
        
        }

        public async Task<List<Actor>> ListActor(int movieId)
        {
            return await _ctx.Acotrs.Where(x => x.MovieId == movieId).ToListAsync();
        }

        public async Task<Actor> UpdateAcotr(int movieId, Actor updatedActor)
        {
            _ctx.Acotrs.Update(updatedActor);

            await _ctx.SaveChangesAsync();

            return updatedActor;
        }
    }
}
