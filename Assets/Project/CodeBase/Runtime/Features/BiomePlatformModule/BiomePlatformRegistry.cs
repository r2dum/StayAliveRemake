using System.Collections.Generic;

namespace CodeBase.Runtime.Features.BiomePlatformModule
{
    public class BiomePlatformRegistry : IBiomePlatformRegistry
    {
        private readonly List<BiomePlatform> _platforms = new();
        private readonly Dictionary<BiomePlatform, bool> _occupationPlatforms = new();

        public IReadOnlyList<BiomePlatform> Platforms => _platforms;

        public void RegisterPlatforms(IEnumerable<BiomePlatform> platforms)
        {
            foreach (BiomePlatform platform in platforms)
            {
                _platforms.Add(platform);
                _occupationPlatforms[platform] = false;
            }
        }

        public bool IsPlatformAvailable(BiomePlatform platform)
        {
            if (_occupationPlatforms.TryGetValue(platform, out bool isOccupied))
                return isOccupied == false;
            return false;
        }

        public void SetOccupied(BiomePlatform platform, bool isOccupied)
        {
            if (_occupationPlatforms.ContainsKey(platform))
                _occupationPlatforms[platform] = isOccupied;
        }
    }
}