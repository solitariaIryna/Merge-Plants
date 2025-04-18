using MergePlants.Gameplay.View.Cells;
using MergePlants.Gameplay.View.Levels;
using MergePlants.Gameplay.View.Plants;
using ObservableCollections;
using R3;
using System.Collections.Generic;
using UnityEngine;

namespace MergePlants.Gameplay.Root.View
{
    public class WorldGameplayRootBinder : MonoBehaviour
    {
        private readonly Dictionary<int, PlantBinder> _createdPlantsMap = new();
        private readonly CompositeDisposable _disposables = new();

        private WorldGameplayRootViewModel _viewModel;

        private Transform _cellsParent;

        public void Bind(WorldGameplayRootViewModel viewModel)
        {
            _viewModel = viewModel;

            if (viewModel.CurrentLevel.Value != null)
                CreateLevel(viewModel.CurrentLevel.Value);

            foreach (var cellViewModel in viewModel.Cells)
                CreateCell(cellViewModel);

            foreach (var plantViewModel in viewModel.AllPlants)
                CreatePlant(plantViewModel);

            _disposables.Add(viewModel.AllPlants.ObserveAdd()
                .Subscribe(e => CreatePlant(e.Value)));

            _disposables.Add(viewModel.AllPlants.ObserveRemove()
                .Subscribe(e => DestroyPlant(e.Value)));

            _disposables.Add(viewModel.CurrentLevel
                .Subscribe(l => CreateLevel(l)));

            _disposables.Add(viewModel.Cells.ObserveAdd()
                .Subscribe(e => CreateCell(e.Value)));
        }

        private void CreateCell(CellViewModel cellViewModel)
        {
            var prefabCellPath = $"Gameplay/Entities/Cell";
            var cellPrefab = Resources.Load<CellBinder>(prefabCellPath);
            var createdCell = Instantiate(cellPrefab);
            createdCell.transform.parent = _cellsParent;
            createdCell.Bind(cellViewModel);
        }

        private void CreateLevel(LevelViewModel levelViewModel)
        {
            var prefabLevelPath = $"Gameplay/Levels/Level_{levelViewModel.Id + 1}";
            var levelPrefab = Resources.Load<LevelBinder>(prefabLevelPath);
            var createdLevel = Instantiate(levelPrefab);
            _cellsParent = createdLevel.CellsParent;
            createdLevel.Bind(levelViewModel);

          //  _createPlantsLevel[plantViewModel.EntityId] = createdLevel;
        }

        private void OnDestroy()
        {
            _disposables.Dispose();
        }

        private void CreatePlant(PlantViewModel plantViewModel)
        {
            var prefabBuildingLevelPath = $"Gameplay/Entities/Plant";
            var plantPrefab = Resources.Load<PlantBinder>(prefabBuildingLevelPath);
            var createdPlant = Instantiate(plantPrefab);

            createdPlant.Bind(plantViewModel);
            createdPlant.Visual.Construct(plantViewModel.Config.VisualConfig);

            _createdPlantsMap[plantViewModel.EntityId] = createdPlant;
        }

        private void DestroyPlant(PlantViewModel buildingViewModel)
        {
            if (_createdPlantsMap.TryGetValue(buildingViewModel.EntityId, out var buildingBinder))
            {
                Destroy(buildingBinder.gameObject);
                _createdPlantsMap.Remove(buildingViewModel.EntityId);
            }
        }

    }
}
