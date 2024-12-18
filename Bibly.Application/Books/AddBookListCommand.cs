namespace Bibly.Application.Books;

public record AddBookListCommand(IEnumerable<BookDto> Books) : IRequest<Unit>;

public class AddBookCommandListHandler : IRequestHandler<AddBookListCommand,Unit>
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    public AddBookCommandListHandler(IBookRepository bookRepository, IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }

    public async Task<Unit> Handle(AddBookListCommand request, CancellationToken cancellationToken)
    {
        foreach (var book in request.Books)
        {
            if (await _authorRepository.ExistById(book.AuthorId))
                throw new NotFoundException("Author", book.AuthorId);
        }

        await _bookRepository.Add(request.Books);
        return Unit.Value;
    }
}

public class AddBookCommandListValidator : AbstractValidator<AddBookListCommand>
{
    public AddBookCommandListValidator()
    {
        RuleFor(x => x.Books)
            .NotEmpty().WithMessage("La liste de livres ne doit pas être vide.");
    }
}


