using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace MergePlants.Infrastructure.StateMachine
{
    public abstract class BaseStateMachine
    {
        protected Dictionary<Type, IExitableState> _states;
        protected IExitableState _currentState;

        public virtual void Initialize() { }

        public async UniTask EnterAsync<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            await state.EnterAsync();
        }

        public async UniTask EnterAsync<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            await state.EnterAsync(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }
    }

}
