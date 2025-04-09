using Zenject;

namespace FarnClash.Infrastructure
{
    public class GameRunner : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<GameInitializer>()
                .AsSingle();
        }
    }
}
