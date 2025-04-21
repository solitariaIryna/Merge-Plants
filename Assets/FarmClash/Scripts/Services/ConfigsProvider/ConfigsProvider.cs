using Cysharp.Threading.Tasks;
using MergePlants.Configs;
using MergePlants.Configs.Plants;
using MergePlants.Configs.Enemies;
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


        public PlantAvatarConfig[] GetAllPlants() =>
            GameConfig.PlantsConfigs.Plants;

        public EnemyAvatarConfig[] GetAllEnemies() =>
            GameConfig.EnemiesConfigs.Enemies;
    }
}
