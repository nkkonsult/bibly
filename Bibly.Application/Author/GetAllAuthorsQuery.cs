namespace Bibly.Application.Author;

public record GetAllAuthorsQuery(string Search) : IRequest<IEnumerable<AuthorDto>>;


public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<AuthorDto>>
{
    private readonly IAuthorRepository _authorRepository;
    public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public async Task<IEnumerable<AuthorDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {

        var authors = await _authorRepository.GetAllAsync(request.Search);

        //throw new Exception("ça marche pas");
        return authors;
    }
}

public class GetAllAGetAllAuthorsQueryValidator : AbstractValidator<GetAllAuthorsQuery>
{
    public GetAllAGetAllAuthorsQueryValidator()
    {
        RuleFor(x => x.Search)
            .MaximumLength(250).WithMessage("La recherche ne doit pas dépasser 250 caractères.")
            ;
    }
}
