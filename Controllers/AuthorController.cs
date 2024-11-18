using book_store_ziad.Data;
using book_store_ziad.Models.Authorr;
using book_store_ziad.Repos.AuthorRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book_store_ziad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepo _repo;
        public AuthorController(IAuthorRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            var result =_repo.GetAuthorList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorDto authorDto) { 
            _repo.AddAuthor(authorDto);
            return Ok();
        }
    }
}
