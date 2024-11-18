using book_store_ziad.Models.Bookk;
using System.ComponentModel.DataAnnotations;

namespace book_store_ziad.Models.Authorr
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }


        public List<Book> books { get; set; }


    }
}
