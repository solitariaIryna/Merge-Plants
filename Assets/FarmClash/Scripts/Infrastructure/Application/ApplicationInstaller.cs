using FarmClash.Services.Factory;
using FarmClash.Services.Window;
using FarnClash.Infrastructure.Application.StatesMachine;
using FarnClash.Services.AssetProvider;
using FarnClash.Services.ConfigsProvider;
using Zenject;

namespace FarnClash.Infrastructure.Application
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
