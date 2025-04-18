using MergePlants.Gameplay.Services;
using MergePlants.State.Levels;


namespace MergePlants.Gameplay.View.Levels
{
    public class LevelViewModel
    {
        private readonly Level _level;
        private readonly LevelsService _levelsService;

        public readonly int Id;

        public LevelViewModel(Level level, LevelsService levelsService)
        {
            _level = level;
            _levelsService = levelsService;
            Id = _level.Id;
        }
    }

}
