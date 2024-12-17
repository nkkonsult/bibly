namespace Bibly.Application.Author;

public record GetSearchAuthorQuery(string LastName) : IRequest<List<AuthorDto>>;

public class GetSearchAuthorQueryHandler(IAuthorRepository authorRepository) : IRequestHandler<GetSearchAuthorQuery, List<AuthorDto>>
{
    public async Task<List<AuthorDto>> Handle(GetSearchAuthorQuery request, CancellationToken cancellationToken)
        => await authorRepository.SearchAll(request.LastName);
}