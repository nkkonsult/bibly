namespace Bibly.Application.Repositories;

public interface IAuthorRepository
{
    Task<int> Add(AuthorDto author);

    Task<List<AuthorDto>> GetAll();

    Task<List<AuthorDto>> SearchAll(string lastName);
}