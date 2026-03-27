using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace CodeBase.Runtime.Core.InputModule
{
    public class InputModuleInstaller : MonoInstaller
    {
        [SerializeField] private InputActionAsset _inputActionAsset;
        
        public override void InstallBindings()
        {
            Container.Bind<InputActionAsset>().FromInstance(_inputActionAsset).AsSingle();
            Container.BindInterfacesAndSelfTo<InputListener>().AsSingle();
        }
    }
}