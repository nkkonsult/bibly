namespace Bibly.Application.Author;
public record AddAuthorCommand(string FirstName, string LastName, DateTime BirthDate) : IRequest<int>;

public class AddAuthorCommandHandler(IAuthorRepository authorRepository) : IRequestHandler<AddAuthorCommand, int>
{
    public async Task<int> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        // Todo : Ajouter controle si l'auteur existe déjà
        //if (await authorRepository.Equals(request.FirstName, request.LastName, request.BirthDate))
        //{
        //    return "Error";
        //}
        return await authorRepository.Add(new AuthorDto(0, request.FirstName, request.LastName, request.BirthDate));
    }
}

public class AddAuthorCommandValidator : AbstractValidator<AddAuthorCommand>
{
    public AddAuthorCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2);
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.BirthDate).NotEmpty();
    }
}