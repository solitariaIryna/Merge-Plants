using Cysharp.Threading.Tasks;
using MergePlants.Constants;
using MergePlants.Infrastructure.App.StatesMachine;
using MergePlants.Infrastructure.Gameplay.StatesMachine;
using Zenject;

namespace MergePlants.Infrastructure
{
    public class ApplicationInitializer : IInitializable
    {
        private readonly ApplicationStateMachine _applicationStateMachine;

        public ApplicationInitializer(ApplicationStateMachine applicationStateMachine)
        {
            _applicationStateMachine = applicationStateMachine;
        }

        public void Initialize()
        {
            _applicationStateMachine.Initialize();
            Run();
           
        }

        private async UniTask Run()
        {
            await _applicationStateMachine.EnterAsync<StartupApplicationState>();

            await _applicationStateMachine.EnterAsync<LoadProgressApplicationState>();

            await _applicationStateMachine.EnterAsync<LoadingSceneApplicationState, string>(ApplicationConstants.GAME_SCENE);

            await  _applicationStateMachine.EnterAsync<GameApplicationState>();
        }
    }

    
}
