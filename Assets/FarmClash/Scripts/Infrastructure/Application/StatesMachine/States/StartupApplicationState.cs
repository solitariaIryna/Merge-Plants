using FarnClash.Infrastructure.StateMachine;
using FarnClash.Services.ConfigsProvider;

namespace FarnClash.Infrastructure.Application.StatesMachine
{
    public class StartupApplicationState : IState
    {
        private readonly IConfigsProvider _configsProvider;

        public StartupApplicationState(IConfigsProvider configsProvider)
        {
            _configsProvider = configsProvider;
        }

        public void Enter()
        {
            _configsProvider.LoadAll();
        }

        public void Exit()
        {
        }
    }    



}
