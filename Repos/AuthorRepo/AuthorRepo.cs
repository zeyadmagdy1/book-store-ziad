using book_store_ziad.Data;
using book_store_ziad.Models.Authorr;

namespace book_store_ziad.Repos.AuthorRepo
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly AppDbContext _context;
        public AuthorRepo(AppDbContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorDto authorDto)
        {
            Author author = new Author {
                 AuthorName = authorDto.AuthorName,
            };
            _context.authors.Add(author);
            _context.SaveChanges();
        }

        public List<AuthorDto> GetAuthorList()
        {
            var result = _context.authors.Select(x => new AuthorDto {AuthorName=x.AuthorName }).ToList();
            return result;
        }
    }
}
