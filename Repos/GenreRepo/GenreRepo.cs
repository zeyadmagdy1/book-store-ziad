using book_store_ziad.Data;
using book_store_ziad.Models.Genree;

namespace book_store_ziad.Repos.GenreRepo
{
    public class GenreRepo : IGenreRepo
    {
        private readonly AppDbContext _context;
        public GenreRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddGenre(GenreDto genreDto)
        {
            Genre genre = new Genre {
                GenreName = genreDto.GenreName,
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public List<GenreDto> GetGenres()
        {
            var result = _context.Genres.Select(gen => new GenreDto { 
            GenreName=gen.GenreName,    
            }).ToList();
            return result;
        }
    }
}
