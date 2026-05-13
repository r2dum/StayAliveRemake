using System.Collections.Generic;

namespace CodeBase.Runtime.Features.BiomePlatformModule
{
    public interface IBiomePlatformRegistry
    {
        IReadOnlyList<BiomePlatform> Platforms { get; }
        void RegisterPlatforms(IEnumerable<BiomePlatform> platforms);
        bool IsPlatformAvailable(BiomePlatform platform);
        void SetOccupied(BiomePlatform platform, bool isOccupied);
    }
}