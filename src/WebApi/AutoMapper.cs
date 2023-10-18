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

            CreateMap<Platforms, PlatformsResponseDTO>();

            CreateMap<Game, GameResponseDTO>();

            CreateMap<SteamGamesResponseDTO, Game>()
                .ConvertUsing(new ValueConverterFromSteamGamesResponseDTOToGame());
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

    public class ValueConverterFromSteamGamesResponseDTOToGame
        : ITypeConverter<SteamGamesResponseDTO, Game>
    {
        public Game Convert(SteamGamesResponseDTO source, Game destination, ResolutionContext context)
        {
            return new Game(
                id: (ulong)source.AppId,
                name: source.Name,
                shortDescription: source.ShortDescription,
                genre: source.Genre,
                releaseDate: source.ReleaseDate,
                requiredAge: (uint)source.RequiredAge,
                publisher: new Publisher(
                    name: source.PublisherName),
                platforms: new Platforms(
                    windows: source.Platforms.Windows,
                    mac: source.Platforms.Mac,
                    linux: source.Platforms.Linux),
                categories: source.CategoriesNames?
                    .Select(categoryName => new Category(name: categoryName))
                    .ToArray() ?? Array.Empty<Category>()
                );
        }
    }
}
