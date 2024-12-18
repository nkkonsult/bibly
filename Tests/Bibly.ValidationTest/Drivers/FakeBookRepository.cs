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
}
