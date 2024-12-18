namespace Bibly.Infra.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public DateTime PublicationDate { get; set; }
    public Author Author { get; set; }
}
