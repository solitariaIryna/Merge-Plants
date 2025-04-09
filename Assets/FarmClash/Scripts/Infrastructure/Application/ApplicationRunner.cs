using Zenject;

namespace FarnClash.Infrastructure.Application
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
