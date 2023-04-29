using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookstore.API.Database.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
