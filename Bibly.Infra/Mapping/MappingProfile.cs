namespace Bibly.Infra.Mapping;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<Book, BookDto>().ReverseMap();        
    }
}
