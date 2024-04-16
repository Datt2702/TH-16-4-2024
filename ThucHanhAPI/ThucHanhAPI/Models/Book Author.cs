using System.ComponentModel.DataAnnotations;

namespace ThucHanhAPI.Models
{
    public class Book_Author
    {
        [Key]
        public int ID { get; set; } // Primary Key
        public int BookID { get; set; } // Foreign Key to Books
        public int AuthorID { get; set; } // Foreign Key to Authors

        // Linking board to Books
        public Book Book { get; set; }
        // Linking board to Authors
        public Author Author { get; set; }
    }
}
//A man who doesn’t spend time with his family can never be a real man.
//Copyright by Duc Dat aka NoFallDamage