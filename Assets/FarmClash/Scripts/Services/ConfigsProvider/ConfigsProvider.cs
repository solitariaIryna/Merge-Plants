using FarnClash.Services.AssetProvider;

namespace FarnClash.Services.ConfigsProvider
{
    public class ConfigsProvider : IConfigsProvider
    {
        private readonly IAssetProvider _assetProvider;

        public ConfigsProvider(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public void LoadAll()
        {

        }


    }
}
