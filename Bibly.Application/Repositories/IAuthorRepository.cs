namespace Bibly.Application.Repositories
{
    public interface IAuthorRepository
    {
        Task<int> Add(AuthorDto author);
        Task<bool> Exist(string firstName, string lastName, DateTime birthDay);
        Task<IEnumerable<AuthorDto>> GetAllAsync(string search);
        Task<bool> ExistById(int id);
    }
}