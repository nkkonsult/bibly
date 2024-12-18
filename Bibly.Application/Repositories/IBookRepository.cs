
namespace Bibly.Application.Repositories;

public interface IBookRepository
{
    Task<int> Add(BookDto bookDto);
}
