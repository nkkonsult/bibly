


namespace Bibly.Application.Repositories;

public interface IBookRepository
{
    Task<int> Add(BookDto bookDto);
    Task Add(IEnumerable<BookDto> books);
    Task<bool> Exist(string title, int authorId, DateTime publicationDate);
}
