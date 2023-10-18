using GamingApi.Common.Exceptions;
using GamingApi.Domain;
using NUnit.Framework;

namespace GamingApi.Tests
{
    public class UnitTest_Domain_Publisher
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Domain_Publisher_Throws_When_Name_Is_Empty()
        {
            Assert.Throws<DomainException>(
                () => { new Publisher(name: string.Empty); }
                );
        }

        [Test]
        public void Domain_Publisher_Throws_When_Name_Is_Null()
        {
            Assert.Throws<DomainException>(
                () => { new Publisher(name: null); }
                );
        }

        [Test]
        public void Domain_Publisher_Throws_When_Name_Is_Full_Spaces()
        {
            Assert.Throws<DomainException>(
                () => { new Publisher(name: new string(' ', count: 10)); }
                );
        }

        [Test]
        public void Domain_Publisher_Passes_When_Name_Is_Present()
        {
            const string name = "name";

            var category = new Publisher(name: name);

            Assert.IsTrue(category.Name.Equals(name));

            Assert.Pass();
        }
    }
}
