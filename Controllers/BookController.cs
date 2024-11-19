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
            var result = _repo.GetBooksAuthorsGenres();
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
        [HttpGet("{id}")]
        public IActionResult GetBook(int id) {
            var result = _repo.GetBook(id);
            return Ok(result);
        }
        [HttpGet("getBookAuthorGenre{id}")]
        public IActionResult getBookAuthorGenre(int id)
        {
            var result = _repo.GetBookAuthorGenre(id);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookDto bookDto)
        {
            _repo.UpdateBook(bookDto, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) { _repo.DeleteBook(id); return Ok(); }
        [HttpPost("JoinBookToAuthor")]
        public IActionResult JoinBookToAuthor(int authorId, int bookId)
        {
            _repo.JoinBookToAuthor(authorId, bookId);
            return Ok();
        }
        [HttpPut("UpdateBookAuthorGenre{id}")]
        public IActionResult UpdateBookAuthorGenre(int id, AddBookAuthorGenreDto addBookAuthorGenreDto)
        {
            _repo.UpdateBookAuthorGenre(id, addBookAuthorGenreDto);
            return Ok();
        }

        [HttpPost("JoinBookGenre")]
        public IActionResult JoinBookGenre(int bookId,int genreId)
        {
            _repo.JoinBookGenre(bookId, genreId);
            return Ok();
        }
    }
}
