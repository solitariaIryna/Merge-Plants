using MergePlants.UI;
using MergePlants.Services.AssetProvider;
using UnityEngine;

namespace MergePlants.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;

        private UIFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        public T CreateWindow<T>(string path) where T : BaseWindow
        {
            T window = _assetProvider.Instantiate<Transform>(path).GetComponent<T>();

            return window;
        }
    }
}
