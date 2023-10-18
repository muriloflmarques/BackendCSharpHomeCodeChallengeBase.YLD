using GamingApi.Common.Exceptions;

namespace GamingApi.Domain
{
    public class Game : BaseDomainClass
    {
        public Game(
            ulong id,
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

        private string _name;
        public string Name
        {
            get => _name;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomainException("Value must be present in Game", nameof(Name));

                _name = value;
            }
        }

        private string _shortDescription;
        public string ShortDescription
        {
            get => _shortDescription;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomainException("Value must be present in Game", nameof(ShortDescription));

                _shortDescription = value;
            }
        }

        private string _genre;
        public string Genre
        {
            get => _genre;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomainException("Value must be present in Game", nameof(Genre));

                _genre = value;
            }
        }

        public DateTime ReleaseDate { get; init; }
        public uint RequiredAge { get; init; }

        private Publisher _publisher;
        public Publisher Publisher
        {
            get => _publisher;
            init
            {
                if (value is null)
                    throw new DomainException("Null value not allowed", nameof(Publisher));

                _publisher = value;
            }
        }

        private Platforms _platforms;
        public Platforms Platforms
        {
            get => _platforms;
            init
            {
                if (value is null)
                    throw new DomainException("Null value not allowed", nameof(Platforms));

                _platforms = value;
            }
        }

        private Category[] _categories;
        public Category[] Categories
        {
            get => _categories;
            init
            {
                if (value is null)
                    throw new DomainException("Null value not allowed", nameof(Categories));
                else if (!value.Any())
                    throw new DomainException("A value must be informed", nameof(Categories));

                _categories = value;
            }
        }
    }

    public class Publisher
    {
        public Publisher(string name) =>
            this.Name = name;

        private string _name;
        public string Name
        {
            get => _name;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomainException("Value must be present in Publisher", nameof(Name));

                _name = value;
            }
        }
    }

    public class Category
    {
        public Category(string name) =>
            this.Name = name;

        private string _name;
        public string Name
        {
            get => _name;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomainException("Value must be present in Category", nameof(Name));

                _name = value;
            }
        }
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
}
