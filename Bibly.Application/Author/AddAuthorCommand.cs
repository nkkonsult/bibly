
using ValidationException = Bibly.Application.Common.Exceptions.ValidationException;

namespace Bibly.Application.Author;


public record AddAuthorCommand(string FirstName, string LastName, DateTime BirthDay) : IRequest<int>;

public class AddAuthorCommandHandler(IAuthorRepository authorRepository) : IRequestHandler<AddAuthorCommand, int>
{  
    public async Task<int> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {      
        if(await authorRepository.Exist(request.FirstName,request.LastName, request.BirthDay))
        {
            throw new ValidationException("L'auteur existe déjà.");
        }   

        return await authorRepository.Add(new AuthorDto(0,request.FirstName, request.LastName, request.BirthDay));
    }
}

public class AddAuthorCommandValidator : AbstractValidator<AddAuthorCommand>
{
    public AddAuthorCommandValidator()
    {

        var textNotEmpty = "Le {PropertyName} ne doit pas être vide.";

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(textNotEmpty)
            .MinimumLength(2).WithMessage("Le prénom doit contenir au moins 2 caractères.")
            .Must(NotContainDigit).WithMessage("Le prénom ne doit pas contenir de chiffres.");
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(textNotEmpty)
            .MinimumLength(2).WithMessage("Le nom de famille doit contenir au moins 2 caractères.");
        RuleFor(x => x.BirthDay)
            .NotEmpty().WithMessage("La date de naissance ne doit pas être vide.");
    }

    private bool NotContainDigit(string arg)
    {
        return !arg.Any(char.IsDigit);
    }
}

