using Bibly.Application.Repositories;
using Bibly.Core.Dtos;

namespace Bibly.ValidationTest.Drivers;

internal class FakeBookRepository : IBookRepository
{
    public static Dictionary<int, BookDto> Books = [];
    public Task<int> Add(BookDto bookDto)
    {
        var id = Books.Count + 1;
        Books.Add(id, bookDto);
        return Task.FromResult(id);
    }

    public async Task Add(IEnumerable<BookDto> books)
    {
        await Task.Yield();
        foreach (var book in books)
        {
            Books.Add(Books.Count + 1, book);
        }
    }

    public async Task<bool> Exist(string title, int authorId, DateTime publicationDate)
    {
        await Task.Yield();
        return  Books.Values.Any(book =>
            book.Title == title &&
            book.AuthorId == authorId &&
            book.PublicationDate == publicationDate);
        
    }
}
