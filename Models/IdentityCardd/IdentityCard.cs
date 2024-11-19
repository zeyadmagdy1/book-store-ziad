using book_store_ziad.Models.Authorr;
using System.ComponentModel.DataAnnotations;

namespace book_store_ziad.Models.IdentityCardd
{
    public class IdentityCard
    {
        [Key]
        public int IdentityCardId { get; set; }

        public string IdentityCardName { get; set; }    

        public Author Author { get; set; }

        public int AuthorId { get; set; }


    }
}
