namespace Bibly.Application.Author.Query;

public record SearchAuthorQuery(string Search) : IRequest<IEnumerable<AuthorDto>>;

public class SearchAuthorQueryHandler(IAuthorRepository authorRepository) : IRequestHandler<SearchAuthorQuery, IEnumerable<AuthorDto>>
{
    public async Task<IEnumerable<AuthorDto>> Handle(SearchAuthorQuery request, CancellationToken cancellationToken)
    {
        return await authorRepository.SearchAuthorQuery(request.Search);
    }
}

