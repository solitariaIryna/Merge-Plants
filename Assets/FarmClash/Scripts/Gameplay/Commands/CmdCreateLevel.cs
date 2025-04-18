using MergePlants.Configs;
using MergePlants.Configs.Levels;
using MergePlants.Services.Command;
using MergePlants.State.Levels;
using MergePlants.State.Root;
using System.Linq;
using UnityEngine;

namespace MergePlants.Gameplay.Commands.Parameters
{
    public class CmdCreateLevel : ICommandWithResult<CmdCreateLevelParameters, Level>
    {
        private readonly GameStateProxy _gameState;
        private readonly GameConfig _gameConfig;

        public CmdCreateLevel(GameStateProxy gameState, GameConfig gameConfig)
        {
            _gameState = gameState;
            _gameConfig = gameConfig;
        }

        public CommandResult<Level> Execute(CmdCreateLevelParameters parameters)
        {
            bool isLevelAlreadyExisted = _gameState.Levels.Any(l => l.Id == parameters.LevelId);

            if (isLevelAlreadyExisted)
            {
                Debug.LogError($"Level with Id = {parameters.LevelId} already exists");
                return new CommandResult<Level>(false, null);
            }

            LevelConfig newLevelConfig = _gameConfig.LevelsConfigs.Levels.First(l => l.LevelId == parameters.LevelId);


            var newLevelState = new LevelData
            {
                Id = parameters.LevelId,
            };

            var newLevelStateProxy = new Level(newLevelState);

            _gameState.Levels.Add(newLevelStateProxy);

            return new CommandResult<Level>(true, newLevelStateProxy);
        }
    }
}
