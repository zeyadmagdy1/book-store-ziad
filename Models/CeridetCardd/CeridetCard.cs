using book_store_ziad.Models.Authorr;
using System.ComponentModel.DataAnnotations;

namespace book_store_ziad.Models.CeridetCardd
{
    public class CeridetCard
    {
        [Key]
        public int CeridetCardDtoId { get; set; }

        public string CeridetCardName { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }

    }
}
