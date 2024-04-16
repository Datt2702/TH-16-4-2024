using System.ComponentModel.DataAnnotations;

namespace ThucHanhAPI.Models
{
    public class Book
    {
        public int ID { get; set; } // Primary Key
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int Rate { get; set; }
        public int Genre { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public int PublisherID { get; set; } // Foreign Key to Publishers

        // Link the board to Publishers
        public Publisher Publisher { get; set; }
        public List<Book_Author> bookAuthors { get; set; }
    }
}
//A man who doesn’t spend time with his family can never be a real man.
//Copyright by Duc Dat aka NoFallDamage