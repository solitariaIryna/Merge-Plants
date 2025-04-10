using Cysharp.Threading.Tasks;
using MergePlants.Infrastructure.StateMachine;
using MergePlants.Services.ConfigsProvider;
using UnityEngine;

namespace MergePlants.Infrastructure.App.StatesMachine
{
    public class StartupApplicationState : IState
    {
        private readonly IConfigsProvider _configsProvider;

        public StartupApplicationState(IConfigsProvider configsProvider)
        {
            _configsProvider = configsProvider;
        }

        public async UniTask EnterAsync()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Input.multiTouchEnabled = false;


           await _configsProvider.LoadAll();
        }

        public void Exit()
        {
        }
    }    



}
