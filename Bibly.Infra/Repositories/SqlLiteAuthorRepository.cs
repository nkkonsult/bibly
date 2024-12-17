using AutoMapper.QueryableExtensions;

namespace Bibly.Infra.Repositories;

public class SqlLiteAuthorRepository(BiblyDbContext context, IMapper mapper) : IAuthorRepository
{
    public async Task<int> Add(AuthorDto author)
    {
        var entity = mapper.Map<Author>(author);

        await context.Authors.AddAsync(entity);

        return await context.SaveChangesAsync();
    }

    public Task<List<AuthorDto>> GetAll()
    {
        var entities = context.Authors.ProjectTo<AuthorDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        return entities;
    }

    public Task<List<AuthorDto>> SearchAll(string lastName)
    {
        return context.Authors.Where(a => a.LastName.Contains(lastName))
            .ProjectTo<AuthorDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }
}