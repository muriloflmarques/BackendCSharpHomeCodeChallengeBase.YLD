namespace GamingApi.Domain
{
    public class Game : BaseDomainClass
    {
        public Game(long id) : base(id) { }

        public Game(
            long id,
            string name,
            string shortDescription,
            string genre,
            DateTime releaseDate,
            uint requiredAge,
            Publisher publisher,
            Platforms platforms,
            params Category[] categories
            )
            : base(id)
        {
            this.Name = name;
            this.ShortDescription = shortDescription;
            this.Genre = genre;
            this.ReleaseDate = releaseDate;
            this.RequiredAge = requiredAge;

            this.Publisher = publisher;
            this.Platforms = platforms;
            this.Categories = categories;
        }

        public string Name { get; init; }
        public string ShortDescription { get; init; }
        public string Genre { get; init; }
        public DateTime ReleaseDate { get; init; }
        public uint RequiredAge { get; init; }

        public Publisher Publisher { get; init; }
        public Platforms Platforms { get; init; }
        public Category[] Categories { get; init; }
    }

    public class Publisher
    {
        public Publisher(string name) =>
            this.Name = name;

        public string Name { get; init; }
    }

    public class Category
    {
        public Category(string name) =>
            this.Name = name;

        public string Name { get; init; }
    }

    public class Platforms
    {
        public Platforms(bool windows, bool mac, bool linux)
        {
            this.Windows = windows;
            this.Mac = mac;
            this.Linux = linux;
        }

        public bool Windows { get; init; }
        public bool Mac { get; init; }
        public bool Linux { get; init; }
    }

    public class Language
    {
        public Language(string name) =>
            this.Name = name;

        public string Name { get; init; }
    }
}
