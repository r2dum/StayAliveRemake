using CodeBase.Runtime.Features.ProjectileModule;

namespace CodeBase.Runtime.Features.ProjectileSpawnerModule
{
    public interface IProjectileFactory
    {
        ProjectileBase CreateProjectile(ProjectileType type);
    }
}