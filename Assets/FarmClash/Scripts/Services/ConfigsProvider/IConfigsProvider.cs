
using Cysharp.Threading.Tasks;
using MergePlants.Configs;
using MergePlants.Configs.Enemies;
using MergePlants.Configs.Plants;

namespace MergePlants.Services.ConfigsProvider
{
    public interface IConfigsProvider
    {
        GameConfig GameConfig { get; }

        EnemyAvatarConfig[] GetAllEnemies();
        PlantAvatarConfig[] GetAllPlants();
        UniTask LoadAll();
    }
}