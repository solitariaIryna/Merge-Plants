using Zenject;

namespace MergePlants.Infrastructure.App
{
    public class ApplicationRunner : MonoInstaller
    {
        public override void InstallBindings()
        {           
            Container
                .BindInterfacesAndSelfTo<ApplicationInitializer>()
                .AsSingle();
        }
    }
}
