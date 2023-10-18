using System.Collections.Immutable;

namespace GamingApi.Common.Helper
{
    public static class PlatformHelper
    {
        static PlatformHelper()
        {
            Platforms = Enum.GetValues(typeof(Platform))
                .Cast<Platform>()
                .ToImmutableArray();
        }

        public static ImmutableArray<Platform> Platforms;
    }
}