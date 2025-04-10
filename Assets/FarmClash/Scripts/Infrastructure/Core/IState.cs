using Cysharp.Threading.Tasks;

namespace MergePlants.Infrastructure.StateMachine
{
    public interface IExitableState
    {
        void Exit();
    }

    public interface IState : IExitableState
    {
        UniTask EnterAsync();
    }

    public interface IPayloadState<T> : IExitableState
    {
        UniTask EnterAsync(T data);
    }
}