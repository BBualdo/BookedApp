using Booked.Enums;
using Booked.Model;

namespace Booked.Data;

public class BooksRepository : IBooksRepository
{
    // Initialize field for storing connection context
    public BooksRepository()
    {

    }

    public Task<IEnumerable<Book>> GetBooksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetBookAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddBookAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBookAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task ToggleBookStatusAsync(int id, ReadingStatus newStatus)
    {
        throw new NotImplementedException();
    }
}
