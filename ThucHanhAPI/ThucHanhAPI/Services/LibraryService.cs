using Microsoft.EntityFrameworkCore;
using ThucHanhAPI.Data;
using ThucHanhAPI.Models;

namespace ThucHanhAPI.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly AppDbContext _db;

        public LibraryService(AppDbContext db)
        {
            _db = db;
        }

        #region Authors

        public async Task<List<Author>> GetAuthorsAsync()
        {
            try
            {
                return await _db.Authors.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Author> GetAuthorAsync(int id, bool includeBooks)
        {
            try
            {
                if (includeBooks) // books should be included
                {
                    return await _db.Authors.Include(b => b.Books)
                        .FirstOrDefaultAsync(i => i.Id == id);
                }

                // Books should be excluded
                return await _db.Authors.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            try
            {
                await _db.Authors.AddAsync(author);
                await _db.SaveChangesAsync();
                return await _db.Authors.FindAsync(author.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            try
            {
                _db.Entry(author).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return author;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteAuthorAsync(Author author)
        {
            try
            {
                var dbAuthor = await _db.Authors.FindAsync(author.Id);

                if (dbAuthor == null)
                {
                    return (false, "Author could not be found");
                }

                _db.Authors.Remove(author);
                await _db.SaveChangesAsync();

                return (true, "Author got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Authors

        #region Books

        public async Task<List<Book>> GetBooksAsync()
        {
            try
            {
                return await _db.Books.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            try
            {
                return await _db.Books.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            try
            {
                await _db.Books.AddAsync(book);
                await _db.SaveChangesAsync();
                return await _db.Books.FindAsync(book.ID); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            try
            {
                _db.Entry(book).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return book;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteBookAsync(Book book)
        {
            try
            {
                var dbBook = await _db.Books.FindAsync(book.ID);

                if (dbBook == null)
                {
                    return (false, "Book could not be found.");
                }

                _db.Books.Remove(book);
                await _db.SaveChangesAsync();

                return (true, "Book got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        Task<List<Author>> ILibraryService.GetAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        Task<Author> ILibraryService.GetAuthorAsync(Guid id, bool includeBooks)
        {
            throw new NotImplementedException();
        }

        Task<Author> ILibraryService.AddAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }

        Task<Author> ILibraryService.UpdateAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }

        Task<(bool, string)> ILibraryService.DeleteAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }

        Task<List<Book>> ILibraryService.GetBooksAsync()
        {
            throw new NotImplementedException();
        }

        Task<Book> ILibraryService.GetBookAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Book> ILibraryService.AddBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        Task<Book> ILibraryService.UpdateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        Task<(bool, string)> ILibraryService.DeleteBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        Task<List<Publisher>> ILibraryService.GetPublisherAsync()
        {
            throw new NotImplementedException();
        }

        Task<Publisher> ILibraryService.GetPublisherAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Publisher> ILibraryService.UpdatePublisherAsync(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        #endregion Books

        #region Publisher

        public async Task<List<Publisher>> GetPublisherAsync()
        {
            try
            {
                return await _db.Publisher.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Publisher> GetPublisherAsync(int id, bool includeBooks)
        {
            try
            {
                if (includeBooks) // books should be included
                {
                    return await _db.Publisher.Include(b => b.Books)
                        .FirstOrDefaultAsync(i => i.ID == id);
                }

                // Books should be excluded
                return await _db.Publisher.FindAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Publisher> AddPublisherAsync(Publisher publisher)
        {
            try
            {
                await _db.Publisher.AddAsync(publisher);
                await _db.SaveChangesAsync();
                return await _db.Publisher.FindAsync(publisher.ID); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Publisher> UpdatePublisherAsync(Publisher publisher)
        {
            try
            {
                _db.Entry(publisher).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return publisher;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeletePublisherAsync(Publisher publisher)
        {
            try
            {
                var dbAuthor = await _db.Publisher.FindAsync(publisher.ID);

                if (dbAuthor == null)
                {
                    return (false, "Publisher could not be found");
                }

                _db.Publisher.Remove(publisher);
                await _db.SaveChangesAsync();

                return (true, "Publisher got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        Task<Publisher> ILibraryService.AddPublisherAsync(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        Task<(bool, string)> ILibraryService.DeletePublisherAsync(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        Task<Publisher> ILibraryService.GetPublisherAsync(object iD)
        {
            throw new NotImplementedException();
        }

        #endregion Publisher

    }
}
//A man who doesn’t spend time with his family can never be a real man.
//Copyright by Duc Dat aka NoFallDamage