using AutoMapper;
using GamingApi.Common.DTO;
using GamingApi.Domain;

namespace Yld.GamingApi.WebApi
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Publisher, string>()
                .ConvertUsing(new ValueConverterFromPublisherToString());

            CreateMap<Category[], string[]>()
                .ConvertUsing(new ValueConverterFromCategoryArrayToStringArray());

            CreateMap<Platforms, PlatformsDTO>();

            CreateMap<Game, GameResponseDTO>()
            //.ForMember(dto => dto.Publisher,
            //    game => game.MapFrom(source => source.GetArrayOfPlatforms())
            //    )
            ;
        }
    }

    public class ValueConverterFromPublisherToString : ITypeConverter<Publisher, string>
    {
        public string Convert(Publisher source, string destination, ResolutionContext context) =>
            source is null
            ?
            throw new Exception("Error while converting Publisher")
            :
            source.Name;
    }

    public class ValueConverterFromCategoryArrayToStringArray : ITypeConverter<Category[], string[]>
    {
        public string[] Convert(Category[] source, string[] destination, ResolutionContext context) =>
            source is null
            ?
            throw new Exception("Error while converting Publisher")
            :
            source.Select(category => category.Name).ToArray();
    }
}
