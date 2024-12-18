using Bibly.Application.Repositories;
using Bibly.Core.Dtos;

namespace Bibly.ValidationTest.Drivers;

internal class FakeBookRepository : IBookRepository
{
    public static Dictionary<int, BookDto> Books = [];

    public async Task<int> Add(BookDto book)
    {
        await Task.Yield();
        Books.Add(Books.Count + 1, book);
        return Books.Count;
    }
}

