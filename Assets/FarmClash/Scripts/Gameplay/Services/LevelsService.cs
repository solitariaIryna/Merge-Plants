using MergePlants.Services.Command;
using ObservableCollections;
using System.Collections.Generic;
using R3;
using MergePlants.Services.SaveLoad;
using MergePlants.State.Levels;
using MergePlants.Gameplay.Commands.Parameters;
using MergePlants.Gameplay.View.Levels;

namespace MergePlants.Gameplay.Services
{
    public class LevelsService
    {
        private readonly ICommandProcessor _cmd;
        private readonly ObservableList<LevelViewModel> _allLevels = new();
        private readonly Dictionary<int, LevelViewModel> _levelsMap = new();

        public IObservableCollection<LevelViewModel> AllLevels => _allLevels;

        public ObservableList<Level> Levels { get; } = new();

        public ReactiveProperty<LevelViewModel> CurrentLevel { get; } = new();

        public LevelsService(ISaveLoadService saveLoadService, ICommandProcessor commandProcessor)
        {
            _cmd = commandProcessor;

            foreach (var level in saveLoadService.GameState.Levels)
            {
                Levels.Add(level);
            }

            foreach (var level in Levels)
            {
                CreateLevelViewModel(level);
            }

            Levels.ObserveAdd().Subscribe(e =>
            {
                CreateLevelViewModel(e.Value);
            });

            Levels.ObserveRemove().Subscribe(e =>
            {
                RemoveLevelViewModel(e.Value);
            });

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

        private void CreateLevelViewModel(Level level)
        {
            var levelViewModel = new LevelViewModel(level, this);
            _allLevels.Add(levelViewModel);
            _levelsMap[level.Id] = levelViewModel;
            CurrentLevel.Value = levelViewModel;
        }

        private void RemoveLevelViewModel(Level level)
        {
            if (_levelsMap.TryGetValue(level.Id, out var vm))
            {
                _allLevels.Remove(vm);
                _levelsMap.Remove(level.Id);
            }
        }
    }
}
