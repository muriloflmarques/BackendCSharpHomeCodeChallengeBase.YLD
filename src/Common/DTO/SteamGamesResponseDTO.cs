using System.Text.Json.Serialization;

namespace GamingApi.Common.DTO
{
    public struct SteamGamesResponseDTO
    {
        [JsonPropertyName("appid")]
        public int AppId;

        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("short_description")]
        public string ShortDescription;

        [JsonPropertyName("genre")]
        public string Genre;

        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate;

        [JsonPropertyName("required_age")]
        public int RequiredAge;

        [JsonPropertyName("publisher")]
        public string PublisherName;

        [JsonPropertyName("platforms")]
        public SteamGamesPlatformsResponseDTO Platforms;

        [JsonPropertyName("categories")]
        public string[] CategoriesNames;
    }

    public struct SteamGamesPlatformsResponseDTO
    {
        [JsonPropertyName("windows")]
        public bool Windows;

        [JsonPropertyName("mac")]
        public bool Mac;

        [JsonPropertyName("linux")]
        public bool Linux;
    }
}
