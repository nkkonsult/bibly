namespace Bibly.Application.Author;

public record GetAllAuthorQuery() : IRequest<List<AuthorDto>>;

public class GetAllAuthorQueryHandler(IAuthorRepository authorRepository) : IRequestHandler<GetAllAuthorQuery, List<AuthorDto>>
{
    public async Task<List<AuthorDto>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        => await authorRepository.GetAll();
}