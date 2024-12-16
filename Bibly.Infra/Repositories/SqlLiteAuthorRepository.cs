
using Bibly.Infra.Persistence;

namespace Bibly.Infra.Repositories;

public class SqlLiteAuthorRepository : IAuthorRepository
{
    private readonly BiblyDbContext _context;
    private readonly IMapper _mapper;

    public SqlLiteAuthorRepository(BiblyDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Add(AuthorDto author)
    {
        var entity = _mapper.Map<Author>(author);

        _context.Authors.Add(entity);

        return await _context.SaveChangesAsync();
    }

    public Task<bool> Equals(string firstName, string lastName, DateTime birthDay)
    {
        throw new NotImplementedException();
    }
}
