using MergePlants.Services.Factory;
using MergePlants.Services.Window;
using MergePlants.Infrastructure.App.StatesMachine;
using MergePlants.Services.AssetProvider;
using MergePlants.Services.ConfigsProvider;
using Zenject;
using MergePlants.Services.SaveLoad;

namespace MergePlants.Infrastructure.App
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
               .Bind<ApplicationStatesFactory>()
               .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ApplicationStateMachine>()
                .AsSingle();

            Container
                .Bind<ISaveLoadService>()
                .To<PlayerPrefsSaveLoadService>()
                .AsSingle();

            Container
                .Bind<IAssetProvider>()
                .To<ResourcesAssetProvider>()
                .AsSingle();

            Container
                .Bind<IConfigsProvider>()
                .To<ConfigsProvider>()
                .AsSingle();

            Container
                .Bind<IUIFactory>()
                .To<UIFactory>()
                .AsSingle();

            Container
               .Bind<IWindowService>()
               .To<WindowService>()
               .AsSingle();

            Container
                .BindInterfacesAndSelfTo<SceneLoader>()
                .AsSingle();
        }
    }
}
