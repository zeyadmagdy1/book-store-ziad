using book_store_ziad.Models.Authorr;
using book_store_ziad.Models.Genree;

namespace book_store_ziad.Models.Bookk
{
    public class AddBookAuthorGenreDto
    {
        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public List<AuthorDto> authorsDtos { get; set; }

        public List<GenreDto> genreDtos { get; set; }

    }
}
