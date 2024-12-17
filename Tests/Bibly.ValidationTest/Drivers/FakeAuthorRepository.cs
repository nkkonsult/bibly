using Bibly.Application.Repositories;
using Bibly.Core.Dtos;

namespace Bibly.ValidationTest.Drivers;

internal class FakeAuthorRepository : IAuthorRepository
{
    public static Dictionary<int,AuthorDto> Authors = [];
    public async Task<int> Add(AuthorDto author)
    {
        await Task.Yield();
        Authors.Add(Authors.Count +1 , author);
        return Authors.Count;
    }

    public async Task<bool> Exist(string firstName, string lastName, DateTime birthDay)
    {
        await Task.Yield();
        return Authors.Values.Any(a => a.FirstName == firstName && a.LastName == lastName && a.BirthDay == birthDay);
    }

    public Task<IEnumerable<AuthorDto>> GetAllAsync(string search)
    {
        throw new NotImplementedException();
    }
}
