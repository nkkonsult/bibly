namespace Bibly.Infra.Repositories;

public class SqlLiteBookRepository(BiblyDbContext context, IMapper mapper) : IBookRepository
{
    public async Task<int> Add(BookDto bookDto)
    {
        Book entity = mapper.Map<Book>(bookDto);
        context.Books.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task Add(IEnumerable<BookDto> books)
    {
        var entities = mapper.Map<IEnumerable<Book>>(books);
        context.Books.AddRange(entities);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Exist(string title, int authorId, DateTime publicationDate)
    {
        return await context.Books.AnyAsync(b => b.Title == title && b.AuthorId == authorId && b.PublicationDate == publicationDate);
    }
}
