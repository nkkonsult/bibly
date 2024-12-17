namespace Bibly.Application.Author.Command;


public record AddAuthorCommand(string FirstName, string LastName, DateTime BirthDay) : IRequest<int>;

public class AddAuthorCommandHandler(IAuthorRepository authorRepository) : IRequestHandler<AddAuthorCommand, int>
{
    public async Task<int> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        //Todo ajouter controle si l'auteur existe deja

        //if(await authorRepository.Equals(request.FirstName, request.LastName, request.BirthDay))
        //{
        //    throw new Exception("Author already exists");
        //}

        return await authorRepository.Add(new AuthorDto(0, request.FirstName, request.LastName, request.BirthDay));
    }
}

public class AddAuthorCommandValidator : AbstractValidator<AddAuthorCommand>
{
    public AddAuthorCommandValidator()
    {
        RuleFor(x => x.FirstName)
        .NotEmpty().WithMessage("Le {PropertyName} ne doit pas être vide.")
        .MinimumLength(2).WithMessage("Le {PropertyName} doit contenir au moins 2 chars.")
        .Must(NotContainDigit).WithMessage("Le {PropertyName} ne doit pas contenir des chiffres.");
        RuleFor(x => x.LastName)
        .NotEmpty()
        .MinimumLength(2);
        RuleFor(x => x.BirthDay)
        .NotEmpty();
    }

    private bool NotContainDigit(string arg)
    {
        return !arg.Any(char.IsDigit);
    }
}