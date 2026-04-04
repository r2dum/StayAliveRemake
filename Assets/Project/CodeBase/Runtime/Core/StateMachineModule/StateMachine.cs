using System;
using System.Collections.Generic;

namespace CodeBase.Runtime.Core.StateMachineModule
{
    public abstract class StateMachine
    {
        private readonly Dictionary<Type, IExitState> _registeredStates = new();
        private IExitState _currentState;

        protected void RegisterState<TState>(TState state) where TState : IExitState =>
            _registeredStates.Add(typeof(TState), state);

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadState<TPayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExitState
        {
            if (_currentState != null)
                _currentState.Exit();

            TState state = GetState<TState>();
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitState =>
            _registeredStates[typeof(TState)] as TState;
    }
}