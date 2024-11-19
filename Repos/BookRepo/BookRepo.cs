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
            var listOfDbNamesOfGenres =_context.Genres.Select(x => x.GenreName).ToList();

            var listOfDtoNamesOfGenres=addBookAuthorGenreDto
                .genreDtos
                .Select(x => x.GenreName)
                .Distinct()
                .ToList();

            var duplicated = listOfDtoNamesOfGenres.Where(x => listOfDbNamesOfGenres.Contains(x)).ToList();
            if(duplicated.Any())
            {
                throw new Exception("Genre is duplicated");
            }


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
            var book = _context.books.FirstOrDefault(x => x.BookId == id);
            if (book == null)
            {
                throw new Exception("Not Found");
            }
            _context.books.Remove(book);
            _context.SaveChanges();
        }

        public BookDto GetBook(int id)
        {
            var result = _context.books.FirstOrDefault(x => x.BookId ==id);
            if (result == null)
            {
                throw new Exception($"Book {id} is not a book");
            }
            return new BookDto {
                DateTime = result.DateTime,
                Title = result.Title,
            };
        }
        public AddBookAuthorGenreDto GetBookAuthorGenre(int id) 
        { 
            var book = _context.books
                .Include(x =>x.authors)
                .Include(x => x.genres)
                .FirstOrDefault(x =>x.BookId ==id);
            if (book == null)
            {
                throw new Exception($"Book {id} is not a book");
            }
            return new AddBookAuthorGenreDto {
                Title =book.Title,
                DateTime = book.DateTime,
                authorsDtos = book.authors.Select(x => new AuthorDto 
                {   
                    AuthorName = x.AuthorName,
                }).ToList(),
                genreDtos=book.genres.Select(x => new GenreDto {
                     GenreName=x.GenreName,
                }).ToList(),
            };  
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

        public void UpdateBook(BookDto bookDto, int id)
        {
            var book = _context.books.FirstOrDefault(x => x.BookId == id);
            if (book == null)
            {
                throw new Exception($"Book {id} is not a book");
            }
            book.Title = bookDto.Title;
            book.DateTime = bookDto.DateTime;
            _context.SaveChanges();
        }

        public void DeleteBookAuthorGenre(int id) {
            var book = _context.books
                .Include(x => x.authors)
                .Include (x => x.genres)
                .FirstOrDefault(x => x.BookId == id);
            if (book == null)
            {
                throw new Exception($"Book {id} is not a book");
            }
            _context.books.Remove(book);
            _context.SaveChanges();
        }


        public void JoinBookToAuthor(int authorId, int bookId) 
        {
            var book = _context
                .books
                .Include(x => x.authors)
                .FirstOrDefault(x => x.BookId == bookId);

            var author = _context.authors.FirstOrDefault(x => x.AuthorId == authorId);

            book.authors.Add(author);
            _context.SaveChanges();

        }

        public void UpdateBookAuthorGenre(int id, AddBookAuthorGenreDto addBookAuthorGenreDto)
        {
            var book = _context
                .books
                .Include(x => x.authors)
                .Include(x => x.genres)
                .FirstOrDefault(x => x.BookId==id);
            book.Title= addBookAuthorGenreDto.Title;

            book.DateTime= addBookAuthorGenreDto.DateTime;
            book.authors = addBookAuthorGenreDto.authorsDtos.Select(x => new Author
            {
                AuthorName = x.AuthorName,
            }).ToList();
            book.genres = addBookAuthorGenreDto.genreDtos.Select(x => new Genre {
                GenreName = x.GenreName,
            }).ToList();
            _context.SaveChanges();
        }

        public void JoinBookGenre(int bookId,int genreId)
        {
            var book =_context.books
                .Include(x => x.genres)
                .FirstOrDefault(x => x.BookId==bookId);
            var genre = _context.Genres.FirstOrDefault(x => x.GenreId==genreId);

            book.genres.Add(genre);
            _context.SaveChanges();
        }

    }
}
