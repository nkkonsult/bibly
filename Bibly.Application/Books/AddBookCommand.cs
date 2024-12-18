namespace Bibly.Application.Books;


public record AddBookCommand(string Title, int Author, DateTime PublicationDate) : IRequest<int>;

public class AddBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<AddBookCommand, int>
{
    public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        return await bookRepository.Add(new BookDto(0, request.Title, request.Author, request.PublicationDate));
    }
}

