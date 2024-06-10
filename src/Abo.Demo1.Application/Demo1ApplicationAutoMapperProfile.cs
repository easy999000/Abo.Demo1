using Abo.Demo1.Books;
using AutoMapper;

namespace Abo.Demo1;

public class Demo1ApplicationAutoMapperProfile : Profile
{
    public Demo1ApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
    }
}
