using MergePlants.Services.Command;
using MergePlants.Infrastructure.Game.Factory;
using MergePlants.Infrastructure.Gameplay.StatesMachine;
using MergePlants.Services.SlowMotion;
using Zenject;
using UnityEngine;
using MergePlants.Gameplay.Services;
using MergePlants.State.Entities;

namespace MergePlants.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private InputService _inputService;
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EntitiesFactory>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<InputService>()
                .AsSingle();

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
                .BindInterfacesAndSelfTo<PlantsService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ResourcesService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<LevelsService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<CellsService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<EnemiesService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<BulletService>()
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
