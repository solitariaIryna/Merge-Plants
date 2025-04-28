using MergePlants.Services.AssetProvider;
using MergePlants.State.Levels;
using Zenject;

namespace MergePlants.Infrastructure.Game.Factory
{
    public class GameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _container;

        public GameFactory(IAssetProvider assetProvider, DiContainer container)
        {
            _assetProvider = assetProvider;
            _container = container;
        }
        public Level CreateLevel(LevelData levelData)
        {
            Level level = _assetProvider.Instantiate<Level>($"Gameplay/Levels/Level_{levelData.Id + 1}", _container);
            level.SetData(levelData);
            return level;
        }

    }
}
