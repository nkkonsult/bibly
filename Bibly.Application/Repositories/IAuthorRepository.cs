
namespace Bibly.Application.Repositories
{
    public interface IAuthorRepository
    {
        Task<int> Add(AuthorDto author);
    }
}