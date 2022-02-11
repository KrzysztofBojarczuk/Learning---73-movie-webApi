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
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _repo;

        public MoviesController(IMapper mapper, IMovieRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movie = await _repo.GetAll();
            var movieGet = _mapper.Map<List<MovieGetDto>>(movie);

            return Ok(movieGet);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _repo.GetMovieById(id);
            var movieGet = _mapper.Map<MovieGetDto>(movie);

            return Ok(movieGet);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] MovieCreateDto movie)
        {
            var movieDomain = _mapper.Map<Movie>(movie);
            await _repo.CreateMvoe(movieDomain);
            var movieGet = _mapper.Map<MovieGetDto>(movieDomain);
            return CreatedAtAction(nameof(GetById), new { id = movieDomain.MovieId }, movieGet);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie([FromBody] MovieCreateDto updateMovie, int id)
        {
            var movie = _mapper.Map<Movie>(updateMovie);
            movie.MovieId = id;
            await _repo.MovieUpdate(movie);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var movie = await _repo.MovieDelete(id);
            if (movie == null)
            {
                return NoContent();
            }

            return NoContent();

        }

    }
}
