
namespace Bibly.Application.Books;

public record AddBookCommand (string Title, int AuthorId, DateTime PublicationDate) : IRequest<int>;

public class AddBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<AddBookCommand, int>
{
    public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        return await bookRepository.Add(new BookDto(request.Title, request.AuthorId, request.PublicationDate));
    }
}

public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
{
    public AddBookCommandValidator()
    {
        
    }
}


