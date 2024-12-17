namespace Bibly.Application.Repositories
{
    public interface IAuthorRepository
    {
        Task<int> Add(AuthorDto author);
        Task<bool> Exist(string firstName, string lastName, DateTime birthDay);
        Task<IEnumerable<AuthorDto>> GetAllAuthor();
        Task<IEnumerable<AuthorDto>> SearchAuthorQuery(string request);
    }
}