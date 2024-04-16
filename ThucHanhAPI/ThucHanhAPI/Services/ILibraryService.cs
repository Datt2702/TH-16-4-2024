using ThucHanhAPI.Models;

namespace ThucHanhAPI.Services
{
    public interface ILibraryService
    {
        // Author Services
        Task<List<Author>> GetAuthorsAsync(); // GET All Authors
        Task<Author> GetAuthorAsync(Guid id, bool includeBooks = false); // GET Single Author
        Task<Author> AddAuthorAsync(Author author); // POST New Author
        Task<Author> UpdateAuthorAsync(Author author); // PUT Author
        Task<(bool, string)> DeleteAuthorAsync(Author author); // DELETE Author

        // Book Services
        Task<List<Book>> GetBooksAsync(); // GET All Books
        Task<Book> GetBookAsync(Guid id); // Get Single Book
        Task<Book> AddBookAsync(Book book); // POST New Book
        Task<Book> UpdateBookAsync(Book book); // PUT Book
        Task<(bool, string)> DeleteBookAsync(Book book); // DELETE Book

        // Publisher Services
        Task<List<Publisher>> GetPublisherAsync(); // GET All Publishers
        Task<Publisher> GetPublisherAsync(Guid id); // Get Single Publishers
        Task<Publisher> AddPublisherAsync(Publisher publisher); // POST New Publishers
        Task<Publisher> UpdatePublisherAsync(Publisher publishers); // PUT Publishers
        Task<(bool, string)> DeletePublisherAsync(Publisher publisher); // DELETE Publishers
        Task<Publisher> GetPublisherAsync(object iD);
    }
}
//Friendship is everything. Friendship is more than talent. It is more than the government. It is almost the equal of family.
//Copyright by Duc Dat aka NoFallDamage