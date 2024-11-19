using book_store_ziad.Models.Bookk;
using book_store_ziad.Models.CeridetCardd;
using book_store_ziad.Models.IdentityCardd;

namespace book_store_ziad.Models.Authorr
{
    public class AddAndGetAll
    {
        public string AuthorName { get; set; }

        public List<BookDto> bookDtos { get; set; }

        public List<CeridetCardDto > ceridetCardDtos { get; set; }

        public IdentityCardDto identityCardDto { get; set; }

    }
}
