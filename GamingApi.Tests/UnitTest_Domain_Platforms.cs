using GamingApi.Common.Exceptions;
using GamingApi.Domain;
using NUnit.Framework;

namespace GamingApi.Tests
{
    public class UnitTest_Domain_Platforms
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Domain_Platforms_Passes_When_Windows_Is_True()
        {
            const bool windows = true;

            var platforms = new Platforms(
                windows: windows,
                mac: !windows,
                linux: !windows);

            Assert.IsTrue(platforms.Windows);

            Assert.Pass();
        }

        [Test]
        public void Domain_Platforms_Passes_When_Windows_Is_False()
        {
            const bool windows = false;

            var platforms = new Platforms(
                windows: windows,
                mac: !windows,
                linux: !windows);

            Assert.IsFalse(platforms.Windows);

            Assert.Pass();
        }

        [Test]
        public void Domain_Platforms_Passes_When_Mac_Is_True()
        {
            const bool mac = true;

            var platforms = new Platforms(
                windows: !mac,
                mac: mac,
                linux: !mac);

            Assert.IsTrue(platforms.Mac);

            Assert.Pass();
        }

        [Test]
        public void Domain_Platforms_Passes_When_Mac_Is_False()
        {
            const bool mac = false;

            var platforms = new Platforms(
                windows: !mac,
                mac: mac,
                linux: !mac);

            Assert.IsFalse(platforms.Mac);

            Assert.Pass();
        }

        [Test]
        public void Domain_Platforms_Passes_When_Linux_Is_True()
        {
            const bool linux = true;

            var platforms = new Platforms(
                windows: !linux,
                mac: !linux,
                linux: linux);

            Assert.IsTrue(platforms.Linux);

            Assert.Pass();
        }

        [Test]
        public void Domain_Platforms_Passes_When_Linux_Is_False()
        {
            const bool linux = false;

            var platforms = new Platforms(
                windows: !linux,
                mac: !linux,
                linux: linux);

            Assert.IsFalse(platforms.Linux);

            Assert.Pass();
        }
    }
}
