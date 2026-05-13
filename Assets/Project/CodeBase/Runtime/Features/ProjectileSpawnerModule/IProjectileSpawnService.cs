using CodeBase.Runtime.Features.BiomePlatformModule;
using CodeBase.Runtime.Features.ProjectileModule;
using Cysharp.Threading.Tasks;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule
{
    public interface IProjectileSpawnService
    {
        UniTaskVoid Spawn(ProjectileType projectileType, BiomePlatform biomePlatform, float flightDuration);
    }
}