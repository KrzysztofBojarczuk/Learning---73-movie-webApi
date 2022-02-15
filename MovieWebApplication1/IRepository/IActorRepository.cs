using MovieWebApplication1.Models;

namespace MovieWebApplication1.IRepository
{
    public interface IActorRepository
    {
        Task<List<Actor>> ListActor(int actorId);
        Task<Actor> CreateActor(int movieId, Actor actor);
        Task<Actor> GetActor(int movieId, int actorId);
        Task<Actor> UpdateAcotr(int movieId, Actor updatedActor);
        Task<Actor> DeleteActor(int movieId, int actorId);
    }
}
