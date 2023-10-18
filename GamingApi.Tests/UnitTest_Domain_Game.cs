using GamingApi.Common.Exceptions;
using GamingApi.Domain;
using NUnit.Framework;

namespace GamingApi.Tests
{
    public class UnitTest_Domain_Game
    {
        private static Tuple<bool, bool, bool> _defaultPlatforms =
            new(true, true, true);

        private static string[] _defaultCategories = new string[]
        {
            "CatergoryOne",
            "CatergoryTwo"
        };

        [SetUp]
        public void Setup()
        {
        }

        private Game GetDefaultGame(
            bool overrideTuplePlatforms = true,
            bool overrideCategoriesNames = true,
            ulong id = 123,
            string name = "Name",
            string shortDescription = "ShortDescription",
            string genre = "Genre",
            DateTime releaseDate = default(DateTime),
            uint requiredAge = 12,
            string publisherName = "PublisherName",
            Tuple<bool, bool, bool> tuplePlatforms = default(Tuple<bool, bool, bool>),
            string[] categoriesNames = default(string[]))
        {
            if (overrideTuplePlatforms)
                tuplePlatforms ??= _defaultPlatforms;

            if (overrideCategoriesNames)
                categoriesNames ??= _defaultCategories;

            return new Game(
                id,
                name,
                shortDescription,
                genre,
                releaseDate,
                requiredAge,
                publisher: this.GetPublisher(publisherName),
                platforms: this.GetPlatforms(tuplePlatforms),
                categoriesNames?.Select(c => { return new Category(name: c); })?.ToArray()
                );
        }

        private Publisher GetPublisher(string publisherName) =>
            string.IsNullOrWhiteSpace(publisherName)
            ?
            null
            :
            new Publisher(name: publisherName);

        private Platforms GetPlatforms(Tuple<bool, bool, bool> tuplePlatforms) =>
           tuplePlatforms == default(Tuple<bool, bool, bool>)
            ?
            null
            :
            new Platforms(
                windows: tuplePlatforms.Item1,
                mac: tuplePlatforms.Item2,
                linux: tuplePlatforms.Item3
                );

        [Test]
        public void Domain_Game_Throws_When_Name_Is_Empty()
        {
            Assert.Throws<DomainException>(
                () => { this.GetDefaultGame(name: string.Empty); }
                );
        }

        [Test]
        public void Domain_Game_Throws_When_Name_Is_Null()
        {
            Assert.Throws<DomainException>(
                () => { this.GetDefaultGame(name: null); }
                );
        }

        [Test]
        public void Domain_Game_Throws_When_Name_Is_Full_Spaces()
        {
            Assert.Throws<DomainException>(
                () => { this.GetDefaultGame(name: new string(' ', count: 10)); }
                );
        }

        [Test]
        public void Domain_Game_Throws_When_ShortDescription_Is_Empty()
        {
            Assert.Throws<DomainException>(
                () => { this.GetDefaultGame(shortDescription: string.Empty); }
                );
        }

        [Test]
        public void Domain_Game_Throws_When_ShortDescription_Is_Null()
        {
            Assert.Throws<DomainException>(
                () => { this.GetDefaultGame(shortDescription: null); }
                );
        }

        [Test]
        public void Domain_Game_Throws_When_ShortDescription_Is_Full_Spaces()
        {
            Assert.Throws<DomainException>(
                () => { this.GetDefaultGame(shortDescription: new string(' ', count: 10)); }
                );
        }

        [Test]
        public void Domain_Game_Throws_When_Genre_Is_Empty()
        {
            Assert.Throws<DomainException>(
                () => { this.GetDefaultGame(genre: string.Empty); }
                );
        }

        [Test]
        public void Domain_Game_Throws_When_Genre_Is_Null()
        {
            Assert.Throws<DomainException>(
                () => { this.GetDefaultGame(genre: null); }
                );
        }

        [Test]
        public void Domain_Game_Throws_When_Categories_Is_Null()
        {
            Assert.Throws<DomainException>(
                () => { this.GetDefaultGame(overrideCategoriesNames: false); }
                );
        }

        [Test]
        public void Domain_Game_Throws_When_Categories_Is_Empty()
        {
            Assert.Throws<DomainException>(
                () => { this.GetDefaultGame(categoriesNames: Array.Empty<string>()); }
                );
        }

        [Test]
        public void Domain_Game_Throws_When_Platforms_Is_Null()
        {
            Assert.Throws<DomainException>(
                () => { this.GetDefaultGame(overrideTuplePlatforms: false); }
                );
        }

        [Test]
        public void Domain_Game_Throws_When_Publisher_Is_Null()
        {
            Assert.Throws<DomainException>(
                () => { this.GetDefaultGame(publisherName: null); }
                );
        }
    }
}
