
using Cysharp.Threading.Tasks;
using MergePlants.Configs;
using MergePlants.Configs.Plants;

namespace MergePlants.Services.ConfigsProvider
{
    public interface IConfigsProvider
    {
        GameConfig GameConfig { get; }

        PlantAvatarConfig[] GetAllPlants();
        UniTask LoadAll();
    }
}