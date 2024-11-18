using book_store_ziad.Models.Authorr;

namespace book_store_ziad.Repos.AuthorRepo
{
    public interface IAuthorRepo
    {
        public void AddAuthor(AuthorDto authorDto);

        public List<AuthorDto> GetAuthorList();



    }
}
