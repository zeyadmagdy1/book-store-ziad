using book_store_ziad.Models.Bookk;
using book_store_ziad.Repos.BookRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book_store_ziad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _repo;
        public BookController(IBookRepo repo) 
        { 
            _repo = repo;
        }

        [HttpGet("GetAllBooksAuthorsGenres")]
        public IActionResult GetAllBooksAuthorsGenres() {
            var result =_repo.GetBooksAuthorsGenres();
            return Ok(result);
        }

        [HttpPost("AddBooksAuthorsGenres")]
        public IActionResult AddBooksAuthorsGenres(AddBookAuthorGenreDto addBookAuthorGenreDto) 
        {
            _repo.AddBookAuthorGenre(addBookAuthorGenreDto);
            return Ok();
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook(BookDto bookDto) {
            _repo.AddBook(bookDto);
            return Ok();
        }

    }
}
