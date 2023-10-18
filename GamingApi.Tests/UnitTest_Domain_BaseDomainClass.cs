using GamingApi.Common.Exceptions;
using GamingApi.Domain;
using NUnit.Framework;

namespace GamingApi.Tests
{
    public class UnitTest_Domain_BaseDomainClass
    {
        [SetUp]
        public void Setup()
        {
            //Only testing the Domain area
            //I think it might be enough to showcase some knowledge
        }

        [Test]
        public void Domain_BaseDomainClass_Throws_When_Id_Is_Zero()
        {
            Assert.Throws<DomainException>(
                () => { new BaseDomainClass(id: 0); }
                );
        }

        [Test]
        public void Domain_BaseDomainClass_Passes_When_Id_Is_Positive()
        {
            const ulong id = 123;

            var category = new BaseDomainClass(id: id);

            Assert.IsTrue(category.Id.Equals(id));

            Assert.Pass();
        }
    }
}
