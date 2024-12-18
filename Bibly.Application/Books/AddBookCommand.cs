
using Bibly.Application.Repositories;

namespace Bibly.Application.Books;

public record AddBookCommand (string Title, int AuthorId, DateTime PublicationDate) : IRequest<int>;

public class AddBookCommandHandler(IBookRepository bookRepository, IAuthorRepository authorRepository) : IRequestHandler<AddBookCommand, int>
{

    public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        if (await authorRepository.ExistById(request.AuthorId))
            throw new NotFoundException("L'auteur n'existe pas", "");
  
        return await bookRepository.Add(new BookDto(request.Title, request.AuthorId, request.PublicationDate));
    }
}

public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
{
    public AddBookCommandValidator()
    {
        
    }
}


