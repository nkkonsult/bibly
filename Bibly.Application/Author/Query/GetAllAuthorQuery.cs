namespace Bibly.Application.Author.Query;

public record GetAllAuthorQuery() : IRequest<IEnumerable<AuthorDto>>;

public class GetAllAuthorQueryHandler(IAuthorRepository authorRepository) : IRequestHandler<GetAllAuthorQuery, IEnumerable<AuthorDto>>
{
    public async Task<IEnumerable<AuthorDto>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
    {
        return await authorRepository.GetAllAuthor();
    }
}

