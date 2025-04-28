using MergePlants.Services.Command;
using ObservableCollections;
using System.Collections.Generic;
using R3;
using MergePlants.Services.SaveLoad;
using MergePlants.State.Levels;
using MergePlants.Gameplay.Commands.Parameters;

namespace MergePlants.Gameplay.Services
{
    public class LevelsService
    {
        private readonly ICommandProcessor _cmd;
        private readonly ObservableList<Level> _allLevels = new();
        private readonly Dictionary<int, Level> _levelsMap = new();

        public IObservableCollection<Level> AllLevels => _allLevels;

        public ObservableList<Level> Levels { get; } = new();

        public ReactiveProperty<Level> CurrentLevel { get; } = new();

        public LevelsService(ISaveLoadService saveLoadService, ICommandProcessor commandProcessor)
        {
            _cmd = commandProcessor;

            foreach (var level in saveLoadService.GameState.Levels)
            {
                Levels.Add(level);
            }

            if (saveLoadService.GameState.CurrentLevelId.Value < Levels.Count)
            {
                var current = Levels[saveLoadService.GameState.CurrentLevelId.Value];
                CurrentLevel.Value = _levelsMap.TryGetValue(current.Id, out var vm) ? vm : null;
            }
        }

        public bool CreateLevel(int number)
        {
            var command = new CmdCreateLevelParameters(number);
            CommandResult<Level> result = _cmd.Process<CmdCreateLevelParameters, Level>(command);

            if (result.Success)
                Levels.Add(result.Result);
            

            return result.Success;
        }

    }
}
