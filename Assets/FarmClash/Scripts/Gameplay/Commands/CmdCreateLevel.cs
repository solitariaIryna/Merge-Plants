using MergerPlants.Configs;
using MergerPlants.Configs.Levels;
using MergePlants.Services.Command;
using MergePlants.State.Levels;
using MergePlants.State.Root;
using System.Linq;
using UnityEngine;

namespace MergePlants.Gameplay.Commands.Parameters
{
    public class CmdCreateLevel : ICommand<CmdCreateLevelParameters>
    {
        private readonly GameStateProxy _gameState;
        private readonly GameConfig _gameConfig;

        public CmdCreateLevel(GameStateProxy gameState, GameConfig gameConfig)
        {
            _gameState = gameState;
            _gameConfig = gameConfig;
        }

        public bool Execute(CmdCreateLevelParameters parameters)
        {
            bool isLevelAlreadyExisted = _gameState.Levels.Any(l => l.Id == parameters.LevelId);

            if (isLevelAlreadyExisted)
            {
                Debug.LogError($"Level with Id = {parameters.LevelId} already exists");
                return false;
            }

            LevelConfig newLevelConfig = _gameConfig.LevelsConfigs.Levels.First(l => l.LevelId == parameters.LevelId);


            var newLevelState = new LevelData
            {
                Id = parameters.LevelId,
                Entities = null
            };

            var newLevelStateProxy = new Level(newLevelState);

            _gameState.Levels.Add(newLevelStateProxy);

            return true;
        }
    }
}
