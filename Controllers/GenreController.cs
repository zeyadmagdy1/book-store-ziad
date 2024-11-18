using book_store_ziad.Models.Genree;
using book_store_ziad.Repos.GenreRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book_store_ziad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepo _repo;
        public GenreController(IGenreRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repo.GetGenres();
            return Ok(result);

        }
        [HttpPost]
        public IActionResult AddGenre(GenreDto genreDto)
        {
            _repo.AddGenre(genreDto);
            return Ok();
        }
    }
}
