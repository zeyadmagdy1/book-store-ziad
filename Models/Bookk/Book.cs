using book_store_ziad.Models.Authorr;
using book_store_ziad.Models.Genree;
using System.ComponentModel.DataAnnotations;

namespace book_store_ziad.Models.Bookk
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public List<Author> authors { get; set; }

        public List<Genre> genres { get; set; }

    }
}
