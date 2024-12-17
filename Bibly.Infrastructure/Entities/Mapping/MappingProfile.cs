namespace Bibly.Infrastructure.Entities.Mapping;
internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorDto>().ReverseMap();
    }
}

