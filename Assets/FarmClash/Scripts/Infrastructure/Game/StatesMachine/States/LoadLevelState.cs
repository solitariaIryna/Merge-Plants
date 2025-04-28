using Cysharp.Threading.Tasks;
using MergePlants.Gameplay.Commands;
using MergePlants.Gameplay.Commands.Parameters;
using MergePlants.Infrastructure.Game.Factory;
using MergePlants.Infrastructure.StateMachine;
using MergePlants.Services.Command;
using MergePlants.Services.ConfigsProvider;
using MergePlants.Services.SaveLoad;
using Unity.Cinemachine;
using UnityEngine;
using MergePlants.Gameplay.Services;
using MergePlants.State.Entities;

namespace MergePlants.Infrastructure.Gameplay.StatesMachine
{
    public class LoadLevelState : IState
    {
        private readonly GameFactory _gameFactory;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IConfigsProvider _configsProvider;
        private readonly ICommandProcessor _commandProcessor;
        private readonly PlantsService _plantService;
        private readonly ResourcesService _resourcesService;
        private readonly LevelsService _levelsService;
        private readonly CellsService _cellsService;
        private readonly EnemiesService _enemiesService;
        private readonly EntitiesFactory _entitiesFactory;

        public LoadLevelState(GameFactory gameFactory, ISaveLoadService saveLoadService, 
            IConfigsProvider configsProvider, ICommandProcessor commandProcessor, PlantsService plantService,
            ResourcesService resourcesService, LevelsService levelsService, CellsService cellService,
            EnemiesService enemiesService, EntitiesFactory entitiesFactory)
        {
            _gameFactory = gameFactory;
            _saveLoadService = saveLoadService;
            _configsProvider = configsProvider;
            _commandProcessor = commandProcessor;
            _plantService = plantService;
            _resourcesService = resourcesService;
            _levelsService = levelsService;
            _cellsService = cellService;
            _enemiesService = enemiesService;
            _entitiesFactory = entitiesFactory;
        }

        public async UniTask EnterAsync()
        {
            RegisterGameplayCommands();
            CinemachineCamera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineCamera>();

            InitWorld();
        }

        private void InitWorld()
        {
          //  int currentLevelId = (_saveLoadService.GameState.GameState.CurrentLevelId);
          //  _saveLoadService.GameState.InitLevel(_gameFactory.CreateLevel(_saveLoadService.GameState.GameState.Levels[currentLevelId]));

            _levelsService.CreateLevel(0);

            var levelConfig = _configsProvider.GameConfig.LevelsConfigs.Levels[_saveLoadService.GameState.CurrentLevelId.Value];
            Vector3 spawnPosition = levelConfig.StartPosition;

            for (int y = 0; y < levelConfig.CellCount.y; y++)
            {
                for (int x = 0; x < levelConfig.CellCount.x; x++)
                {
                    _cellsService.CreateCell(y + x, true, false, new Vector3(spawnPosition.x, spawnPosition.y, 0));
                    spawnPosition.x += levelConfig.CellOffset.x;
                }
                spawnPosition.x = levelConfig.StartPosition.x;
                spawnPosition.y -= levelConfig.CellOffset.y;
            }

            _plantService.PlacePlant(1, 0);
            _plantService.PlacePlant(1, 1);
        }

        private void RegisterGameplayCommands()
        {
            _commandProcessor.RegisterCommand(new CmdCreateLevel(_saveLoadService.GameState, _configsProvider.GameConfig, _gameFactory));
            _commandProcessor.RegisterCommand(new CmdResourceAdd(_saveLoadService.GameState));
            _commandProcessor.RegisterCommand(new CmdResourceSpend(_saveLoadService.GameState));
            _commandProcessor.RegisterCommand(new CmdPlacePlant(_saveLoadService.GameState, _cellsService, _plantService, _entitiesFactory));
            _commandProcessor.RegisterCommand(new CmdDeletePlant(_saveLoadService.GameState, _cellsService, _plantService));
            _commandProcessor.RegisterCommand(new CmdCreateCell(_saveLoadService.GameState, _entitiesFactory));
            _commandProcessor.RegisterCommand(new CmdCreateEnemy(_saveLoadService.GameState, _entitiesFactory, _enemiesService));
            _commandProcessor.RegisterCommand(new CmdCreateBullet(_saveLoadService.GameState, _entitiesFactory));
        }

        public void Exit()
        {

        }
    }        
}
