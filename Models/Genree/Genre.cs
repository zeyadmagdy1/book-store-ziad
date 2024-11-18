using book_store_ziad.Models.Bookk;
using System.ComponentModel.DataAnnotations;

namespace book_store_ziad.Models.Genree
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        public string GenreName { get; set; }

        public List<Book> books { get; set; }
    }
}
