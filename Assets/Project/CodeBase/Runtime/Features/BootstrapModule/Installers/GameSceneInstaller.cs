using CodeBase.Runtime.Features.PlayerModule;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Features.BootstrapModule.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;

        public override void InstallBindings()
        {
            Container
                .Bind<Player>()
                .FromInstance(_player)
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<PlayerInput>()
                .AsSingle();
        }
    }
}