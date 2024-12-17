
namespace Bibly.Infrastructure.Repositories;
public class SqlLiteAuthorRepository : IAuthorRepository
{
    private readonly BiblyDbContext _ctx;
    private readonly IMapper _mapper;

    public SqlLiteAuthorRepository(IMapper mapper, BiblyDbContext ctx)
    {
        _mapper = mapper;
        _ctx = ctx;
    }

    public async Task<int> Add(AuthorDto authorDto)
    {
        var entity = _mapper.Map<Author>(authorDto);

        _ctx.Authors.Add(entity);

        return await _ctx.SaveChangesAsync();
    }

    public Task<bool> Equals(string firstName, string lastName, DateTime birthDate)
    {
        throw new NotImplementedException();
    }
}

