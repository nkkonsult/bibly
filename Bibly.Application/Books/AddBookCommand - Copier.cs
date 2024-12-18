
using Bibly.Application.Repositories;

namespace Bibly.Application.Books;

public record AddBookCommand (int Id, string Title, int AuthorId, DateTime PublicationDate) : IRequest<int>;

public class AddBookCommandHandler(IBookRepository bookRepository, IAuthorRepository authorRepository) : IRequestHandler<AddBookCommand, int>
{

    public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        if (await authorRepository.ExistById(request.AuthorId))
            throw new NotFoundException("Author", request.AuthorId);
  
        
        return await bookRepository.Add(new BookDto(request.Id, request.Title, request.AuthorId, request.PublicationDate));
    }
}

public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
{
    public AddBookCommandValidator()
    {
        RuleFor(b => b.PublicationDate).LessThan(DateTime.Now).WithMessage("La date de publication doit être inférieure à la date actuelle");
    }
}


