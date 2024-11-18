using book_store_ziad.Models.Bookk;

namespace book_store_ziad.Repos.BookRepo
{
    public interface IBookRepo
    {
        public void AddBookAuthorGenre(AddBookAuthorGenreDto addBookAuthorGenreDto);

        public void AddBook(BookDto bookDto);

        public List<AddBookAuthorGenreDto> GetBooksAuthorsGenres();

        public BookDto GetBook(int id);

        public void DeleteBook(int id);

        public void UpdateBook(BookDto bookDto,int id);

        public AddBookAuthorGenreDto GetBookAuthorGenre(int id);

        public void DeleteBookAuthorGenre(int id);
        public void JoinBookToAuthor(int authorId, int bookId);
    }
}
