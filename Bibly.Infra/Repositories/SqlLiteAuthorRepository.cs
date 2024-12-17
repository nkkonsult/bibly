using AutoMapper.QueryableExtensions;

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

    public Task<bool> Exist(string firstName, string lastName, DateTime birthDay)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<AuthorDto>> GetAllAuthor()
    {
        return await _context.Authors
            .ProjectTo<AuthorDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<AuthorDto>> SearchAuthorQuery(string search)
    {
        return await _context.Authors
            .Where(x => EF.Functions.Like(x.FirstName.ToLower(), $"%{search.ToLower()}%") || EF.Functions.Like(x.LastName.ToLower(), $"%{search.ToLower()}%"))
            .ProjectTo<AuthorDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
