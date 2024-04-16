using System.ComponentModel.DataAnnotations;

namespace ThucHanhAPI.Models
{
    public class Publisher
    {
        [Key]
        public int ID { get; set; } // Khóa chính
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
//A man who doesn’t spend time with his family can never be a real man.
//Copyright by Duc Dat aka NoFallDamage