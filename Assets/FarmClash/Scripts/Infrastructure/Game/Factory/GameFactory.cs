using MergePlants.Services.AssetProvider;
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


    }
}
