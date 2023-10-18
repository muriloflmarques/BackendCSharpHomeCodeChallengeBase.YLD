namespace GamingApi.Common.DTO
{
    public struct GameResponseDTO
    {
        public long Id;
        public string Name;
        public string ShortDescription;
        public string Publisher;
        public string Genre;
        public string[] Categories;
        public PlatformsDTO Platforms;
        public string ReleaseDate;
        public uint RequiredAge;
    }

    public struct PlatformsDTO
    {
        public bool Windows;
        public bool Mac;
        public bool Linux;
    }
}
