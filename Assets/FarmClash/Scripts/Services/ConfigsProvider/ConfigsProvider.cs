using Cysharp.Threading.Tasks;
using MergerPlants.Configs;
using MergePlants.Services.AssetProvider;

namespace MergePlants.Services.ConfigsProvider
{
    public class ConfigsProvider : IConfigsProvider
    {
        private readonly IAssetProvider _assetProvider;
        public GameConfig GameConfig { get; private set; }
        public ConfigsProvider(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public async UniTask LoadAll()
        {
            GameConfig = _assetProvider.Load<GameConfig>("Configs/GameConfig");
            await UniTask.WaitUntil(() => GameConfig != null);
        }

    }
}
