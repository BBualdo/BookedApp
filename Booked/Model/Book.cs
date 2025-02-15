using Booked.Enums;

namespace Booked.Model;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public ReadingStatus? Status { get; set; }
    public string? CoverImageUrl { get; set; }
}