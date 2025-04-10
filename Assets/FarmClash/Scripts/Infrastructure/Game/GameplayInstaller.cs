using MergePlants.Services.Command;
using MergePlants.Infrastructure.Game.Factory;
using MergePlants.Infrastructure.Gameplay.StatesMachine;
using MergePlants.Services.SlowMotion;
using Zenject;

namespace MergePlants.Infrastructure.Installers
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
