using book_store_ziad.Models.Genree;

namespace book_store_ziad.Repos.GenreRepo
{
    public interface IGenreRepo
    {
        public void AddGenre(GenreDto genreDto);

        public List<GenreDto> GetGenres();
    }
}
