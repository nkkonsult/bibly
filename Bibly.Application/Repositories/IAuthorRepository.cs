


namespace Bibly.Application.Repositories
{
    public interface IAuthorRepository
    {
        Task<int> Add(AuthorDto author);
        Task<bool> Equals(string firstName, string lastName, DateTime birthDay);
    }
}