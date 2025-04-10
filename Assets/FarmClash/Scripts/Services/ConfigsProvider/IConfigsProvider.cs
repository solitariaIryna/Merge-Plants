
using Cysharp.Threading.Tasks;
using FarmClash.Configs;

namespace MergePlants.Services.ConfigsProvider
{
    public interface IConfigsProvider
    {
        GameConfig GameConfig { get; }

        UniTask LoadAll();
    }
}