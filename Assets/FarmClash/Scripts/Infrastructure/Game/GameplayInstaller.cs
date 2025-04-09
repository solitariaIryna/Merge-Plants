using FarmClash.Services.Command;
using FarnClash.Infrastructure.Game.Factory;
using FarnClash.Infrastructure.Gameplay.StatesMachine;
using FarnClash.Services.SlowMotion;
using Zenject;

namespace FarnClash.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ICommandProcessor>()
                .To<CommandProcessor>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<SlowMotionService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<GameFactory>()
                .AsSingle();

            Container
               .Bind<GameplayStatesFactory>()
               .AsSingle();

            Container
                .BindInterfacesAndSelfTo<GameplayStateMachine>()
                .AsSingle();


        }
    }
}
