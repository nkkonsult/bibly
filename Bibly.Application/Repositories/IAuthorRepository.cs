namespace Bibly.Application.Repositories;
public interface IAuthorRepository
{
    Task<int> Add(AuthorDto authorDto);
    Task<bool> Equals(string firstName, string lastName, DateTime birthDate);
}
