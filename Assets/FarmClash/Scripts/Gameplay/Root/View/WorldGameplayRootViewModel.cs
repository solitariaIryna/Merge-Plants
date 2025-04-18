using MergePlants.Gameplay.Services;
using MergePlants.Gameplay.View.Cells;
using MergePlants.Gameplay.View.Levels;
using MergePlants.Gameplay.View.Plants;
using ObservableCollections;
using R3;

namespace MergePlants.Gameplay.Root.View
{
    public class WorldGameplayRootViewModel
    {
        private readonly ResourcesService _resourcesService;

        public readonly IObservableCollection<PlantViewModel> AllPlants;
        public readonly IObservableCollection<CellViewModel> Cells;

        public ReactiveProperty<LevelViewModel> CurrentLevel { get; }

        public WorldGameplayRootViewModel(PlantsService plantsService, ResourcesService resourcesService,
            LevelsService levelsService, CellsService cellsService)
        {
            _resourcesService = resourcesService;
            AllPlants = plantsService.AllPlants;
            CurrentLevel = levelsService.CurrentLevel;
            Cells = cellsService.AllCells;

            //resourcesService.ObserveResource(ResourceType.SoftCurrency)
            //    .Subscribe(newValue => Debug.Log($"SoftCurrency: {newValue}"));

            //resourcesService.ObserveResource(ResourceType.HardCurrency)
            //    .Subscribe(newValue => Debug.Log($"HardCurrency: {newValue}"));
        }

        //public void HandleTestInput()
        //{
        //    var rResourceType = (ResourceType)Random.Range(0, Enum.GetNames(typeof(ResourceType)).Length);
        //    var rValue = Random.Range(1, 1000);
        //    var rOperation = Random.Range(0, 2);

        //    if (rOperation == 0)
        //    {
        //        _resourcesService.AddResources(rResourceType, rValue);
        //        return;
        //    }

        //    _resourcesService.TrySpendResources(rResourceType, rValue);
        //}
    }
}
