using Zenject;

namespace CodeBase.Runtime.Core.StateMachineModule
{
    public class StatesFactory : IStatesFactory
    {
        private readonly IInstantiator _instantiator;

        public StatesFactory(IInstantiator instantiator) =>
            _instantiator = instantiator;

        public TState Create<TState>() where TState : IExitState =>
            _instantiator.Instantiate<TState>();
    }
}