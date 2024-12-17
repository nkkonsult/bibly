namespace Bibly.Infra.Entities;

public class Author : BaseEntity
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime BirthDay { get; set; }
}
