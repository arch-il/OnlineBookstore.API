using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.API.Database.Entities
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
