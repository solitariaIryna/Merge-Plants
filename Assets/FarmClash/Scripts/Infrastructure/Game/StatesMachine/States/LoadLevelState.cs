using Cysharp.Threading.Tasks;
using FarmClash.Gameplay.Commands;
using MergePlants.Gameplay.Commands.Parameters;
using MergePlants.Infrastructure.Game.Factory;
using MergePlants.Infrastructure.StateMachine;
using MergePlants.Services.Command;
using MergePlants.Services.ConfigsProvider;
using MergePlants.Services.SaveLoad;
using Unity.Cinemachine;
using UnityEngine;

namespace MergePlants.Infrastructure.Gameplay.StatesMachine
{
    public class LoadLevelState : IState
    {
        private readonly GameFactory _gameFactory;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IConfigsProvider _configsProvider;
        private readonly ICommandProcessor _commandProcessor;

        public LoadLevelState(GameFactory gameFactory, ISaveLoadService saveLoadService, 
            IConfigsProvider configsProvider, ICommandProcessor commandProcessor)
        {
            _gameFactory = gameFactory;
            _saveLoadService = saveLoadService;
            _configsProvider = configsProvider;
            _commandProcessor = commandProcessor;
        }

        public async UniTask EnterAsync()
        {
            RegisterGameplayCommands();
            CinemachineCamera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineCamera>();
        }

        private void RegisterGameplayCommands()
        {
            _commandProcessor.RegisterCommand(new CmdCreateLevel(_saveLoadService.GameState, _configsProvider.GameConfig));
            _commandProcessor.RegisterCommand(new CmdResourceAdd(_saveLoadService.GameState));
            _commandProcessor.RegisterCommand(new CmdResourceSpend(_saveLoadService.GameState));
        }

        public void Exit()
        {

        }
    }        
}
