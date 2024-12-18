
namespace Bibly.Application.Books;

public record AddBookCommand (string Title, int AuthorId, DateTime PublicationDate) : IRequest<int>;

public class AddBookCommandHandler(IBookRepository bookRepository, IAuthorRepository authorRepository) : IRequestHandler<AddBookCommand, int>
{
    public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        if(!await authorRepository.Exist(request.AuthorId))
            throw new NotFoundException("Author",request.AuthorId);

        return await bookRepository.Add(new BookDto(request.Title, request.AuthorId, request.PublicationDate));
    }
}

public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
{
    public AddBookCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Le titre ne doit pas être vide.")
            .MinimumLength(2).WithMessage("Le titre doit contenir au moins 2 caractères.");
    }
}


