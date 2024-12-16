
namespace Bibly.Application.Author;


public record AddAuthorCommand(string FirstName, string LastName, DateTime BirthDay) : IRequest<int>;

public class AddAuthorCommandHandler(IAuthorRepository authorRepository) : IRequestHandler<AddAuthorCommand, int>
{  
    public async Task<int> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        //Todo ajouter controle si l'auteur existe deja

        if(await authorRepository.Equals(request.FirstName, request.LastName, request.BirthDay))
        {
            throw new Exception("Author already exists");
        }

        return await authorRepository.Add(new AuthorDto(0,request.FirstName, request.LastName, request.BirthDay));
    }
}

public class AddAuthorCommandValidator : AbstractValidator<AddAuthorCommand>
{
    public AddAuthorCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2);
        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(2);
        RuleFor(x => x.BirthDay)
            .NotEmpty();
    }
}

