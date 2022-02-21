using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieWebApplication1.Dttos;
using MovieWebApplication1.IRepository;
using MovieWebApplication1.Models;

namespace MovieWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorRepository _acotrRepo;
        private readonly IMapper _mapper;

        public ActorsController(IActorRepository acotrRepo, IMapper mapper)
        {
            _acotrRepo = acotrRepo;
            _mapper = mapper;
        }

        [HttpGet("{movieId}/actors")]
        public async Task<IActionResult> GetActors(int movieId)
        {
            var actor = await _acotrRepo.ListActor(movieId);
            var mappedActor = _mapper.Map<List<ActorGetDto>>(actor);
            return Ok(mappedActor);
        }
        [HttpGet("{movieId}/actors/{actorId}")]
        public async Task<IActionResult> GetAcotrsById(int movieId, int actorId)
        {
            var actor = await _acotrRepo.GetActor(movieId, actorId);
            var mappedComment = _mapper.Map<ActorGetDto>(actor);
            return Ok(mappedComment);
        }
        [HttpPost("{movieId}/actors")]
        public async Task<IActionResult> AddActor(int movieId, [FromBody] ActorCreateDto newActor)
        {
            var actor = _mapper.Map<Actor>(newActor);

            await _acotrRepo.CreateActor(movieId, actor);

            var mappedActor = _mapper.Map<ActorGetDto>(actor);

            return CreatedAtAction(nameof(GetAcotrsById), new { movieId = movieId, actorId = mappedActor }, mappedActor);
        }
        [HttpDelete("{movieId}/actors/{actorId}")]
        public async Task<IActionResult> DeleteActor(int movieId, int actorId)
        {
            var actor = await _acotrRepo.DeleteActor(movieId, actorId);

            if (actor == null)
            {
                return NotFound("Acotor not found");
            }
            return NoContent();
        }
        [HttpPut("{movieId}/actors/{actorId}")]
        public async Task<IActionResult> UpdateActorMovies(int movieId, int actorId, [FromBody] ActorCreateDto actorUpdate)
        {
            var toUpdate = _mapper.Map<Actor>(actorUpdate);
       
            toUpdate.ActorId = actorId;

            toUpdate.MovieId = movieId;
            

            await _acotrRepo.UpdateAcotr(movieId, toUpdate);
            
            return NoContent();
        }
    }
}

