namespace Bibly.Application.Author;


public record AddAuthorCommand(string FirstName, string LastName, DateTime BirthDay) : IRequest<int>;

public class AddAuthorCommandHandler(IAuthorRepository authorRepository) : IRequestHandler<AddAuthorCommand, int>
{  
    public async Task<int> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        return await authorRepository.Add(new AuthorDto(0,request.FirstName, request.LastName, request.BirthDay));
    }
}


