using Booked.Enums;
using Booked.Model;

namespace Booked.Data;

public interface IBooksRepository
{
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book> GetBookAsync(int id);
    Task AddBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(int id);
    Task ToggleBookStatusAsync(int id, ReadingStatus newStatus);
}
