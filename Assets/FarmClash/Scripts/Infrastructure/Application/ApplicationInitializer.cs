using FarnClash.Constants;
using FarnClash.Infrastructure.Application.StatesMachine;
using Zenject;

namespace FarnClash.Infrastructure
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
            _applicationStateMachine.Enter<StartupApplicationState>();
            _applicationStateMachine.Enter<LoadingSceneApplicationState, string>(ApplicationConstants.GAME_SCENE);
           
        }
    }

    
}
