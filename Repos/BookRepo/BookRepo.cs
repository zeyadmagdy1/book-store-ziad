using book_store_ziad.Data;
using book_store_ziad.Models.Authorr;
using book_store_ziad.Models.Bookk;
using book_store_ziad.Models.Genree;
using Microsoft.EntityFrameworkCore;

namespace book_store_ziad.Repos.BookRepo
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDbContext _context;

        public BookRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookDto bookDto)
        {
            Book book = new Book {
                DateTime = bookDto.DateTime,
                Title = bookDto.Title,
            };
            _context.books.Add(book);
            _context.SaveChanges();
        }

        public void AddBookAuthorGenre(AddBookAuthorGenreDto addBookAuthorGenreDto)
        {
            Book book = new Book {
                Title = addBookAuthorGenreDto.Title,
                DateTime = addBookAuthorGenreDto.DateTime,
                authors = addBookAuthorGenreDto.authorsDtos
               .Select(x => new Author {
                   AuthorName = x.AuthorName,
               }).ToList(),
                genres = addBookAuthorGenreDto.genreDtos.Select(x => new Genre {
                GenreName = x.GenreName,    
                }).ToList(),
            };
            _context.books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public BookDto GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public List<AddBookAuthorGenreDto> GetBooksAuthorsGenres()
        {
            var result = _context.books
                .Include(x => x.authors)
                .Include(x => x.genres)
                .Select(x => new AddBookAuthorGenreDto {
                    Title = x.Title,
                    DateTime = x.DateTime,
                    authorsDtos = x.authors.Select(x => new AuthorDto {
                         AuthorName =x.AuthorName
                    }).ToList(),
                    genreDtos=x.genres.Select(x => new GenreDto {
                    GenreName=x.GenreName
                    }).ToList(),
                }).ToList();
            return result;
        }

        public void UpdateBook(BookDto bookDto)
        {
            throw new NotImplementedException();
        }
    }
}
