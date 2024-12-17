namespace Bibly.Infra.Repositories;

public class SqlLiteAuthorRepository(BiblyDbContext context, IMapper mapper) : IAuthorRepository
{
    private readonly BiblyDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<int> Add(AuthorDto author)
    {
        var entity = _mapper.Map<Author>(author);
        _context.Authors.Add(entity);

        return await _context.SaveChangesAsync();
    }

    public async Task<bool> Equals(string firstName, string lastName, DateTime birthDay)
    {
        return await _context.Authors.AnyAsync(x => x.FirstName == firstName && x.LastName == lastName && x.BirthDay == birthDay);
    }

    public async Task<IEnumerable<AuthorDto>> GetAllAsync(string search)
    {
        return await _context.Authors
            .Where(x => EF.Functions.Like(x.FirstName.ToLower(), $"%{search.ToLower()}%") || EF.Functions.Like(x.LastName.ToLower(), $"%{search.ToLower()}%"))
            .ProjectTo<AuthorDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
