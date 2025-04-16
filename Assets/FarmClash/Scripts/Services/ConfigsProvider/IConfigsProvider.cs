
using Cysharp.Threading.Tasks;
using MergerPlants.Configs;

namespace MergePlants.Services.ConfigsProvider
{
    public interface IConfigsProvider
    {
        GameConfig GameConfig { get; }

        UniTask LoadAll();
    }
}