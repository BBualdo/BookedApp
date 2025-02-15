using Booked.Enums;
using Booked.Model;
using Microsoft.Data.Sqlite;

namespace Booked.Data;

public class BooksRepository : IBooksRepository
{
    string _dbPath { get; set; }
    public BooksRepository()
    {
        _dbPath = "Data Source=" + Path.Combine(FileSystem.AppDataDirectory, "booked.db");
        Init();
        SeedBooks();
    }

    private void Init()
    {
        using var connection = new SqliteConnection(_dbPath);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = @"CREATE TABLE IF NOT EXISTS Books(
                                    id INTEGER PRIMARY KEY,
                                    title TEXT NOT NULL,
                                    author TEXT NOT NULL,
                                    status INTEGER NULL,
                                    cover_image_url TEXT NULL
                                    )";
        command.ExecuteNonQuery();
    }

    private void SeedBooks()
    {
        using var connection = new SqliteConnection(_dbPath);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM Books";
        if ((int?)command.ExecuteScalar() > 0) return;

        command.CommandText = @"INSERT INTO Books(title, author, status, cover_image_url) VALUES
        ('The Green Mile', 'Stephen King', 2, 'https://covers.shakespeareandcompany.com/97805750/9780575084346.jpg'),
        ('To Kill a Mockingbird', 'Harper Lee', NULL, 'https://cdn.kobo.com/book-images/4e1af857-e0e8-45fa-8922-e4bff584beca/1200/1200/False/to-kill-a-mockingbird-4.jpg'),
        ('It', 'Stephen King', 1, 'https://thebooks.pl/wp-content/uploads/2023/11/it.jpg'),
        ('The Witcher: Last Wish', 'Andrzej Sapkowski', 2, 'https://m.media-amazon.com/images/I/71nEod9HgvL._AC_UF894,1000_QL80_.jpg'),
        ('Sherlock Holmes', 'Arthur Conan Doyle', NULL, 'https://m.media-amazon.com/images/I/715In3tGEQL._AC_UF1000,1000_QL80_.jpg');";
        command.ExecuteNonQuery();
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        using var connection = new SqliteConnection(_dbPath);
        await connection.OpenAsync();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Books";

        using var reader = await command.ExecuteReaderAsync();
        var books = new List<Book>();
        while (reader.Read())
        {
            var book = new Book()
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Author = reader.GetString(2),
                Status = reader.IsDBNull(3) ? null : (ReadingStatus)reader.GetInt32(3),
                CoverImageUrl = reader.IsDBNull(4) ? null : reader.GetString(4)
            };
            books.Add(book);
        }

        return books;
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
