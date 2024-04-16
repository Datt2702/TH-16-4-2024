using System.ComponentModel.DataAnnotations;

namespace ThucHanhAPI.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        // One-to-many relationship with books
        public List<Book>? Books { get; set; }
    }
}
//A man who doesn’t spend time with his family can never be a real man.
//Copyright by Duc Dat aka NoFallDamage
