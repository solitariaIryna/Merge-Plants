using MergePlants.Services.Command;
using MergePlants.State.Entities.Plants;
using MergePlants.Gameplay.Commands.Parameters;
using MergePlants.Gameplay.View.Plants;
using ObservableCollections;
using System.Collections.Generic;
using R3;
using MergePlants.Services.SaveLoad;
using MergePlants.State.Entities;
using MergePlants.Configs.Plants;
using MergePlants.Services.ConfigsProvider;
using System.Linq;

namespace MergePlants.Gameplay.Services
{
    public class PlantsService
    {
        public IObservableCollection<PlantViewModel> AllPlants => _allPlants;

        private ObservableList<PlantEntity> _plants = new();

        private readonly ObservableList<PlantViewModel> _allPlants = new();
        private readonly Dictionary<int, PlantAvatarConfig> _plantsConfigs = new();
        private readonly Dictionary<int, PlantViewModel> _plantsMap = new();
        private readonly ICommandProcessor _cmd;
        private readonly IConfigsProvider _configsProvider;

        public PlantsService(ISaveLoadService saveLoadService,    
            ICommandProcessor cmd, IConfigsProvider configsProvider)
        {
            _cmd = cmd;
            _configsProvider = configsProvider;

            _plantsConfigs = _configsProvider.GetAllPlants().ToDictionary(p => p.Config.Level);

            if (saveLoadService.GameState.Levels.Count > saveLoadService.GameState.CurrentLevelId.Value)
            {
                foreach (Entity entity in saveLoadService.GameState.Levels[saveLoadService.GameState.CurrentLevelId.Value].Entities)
                {
                    if (entity is PlantEntity plantEntity)
                        _plants.Add(plantEntity);
                }

                foreach (var plantEntity in _plants)
                {
                    CreatePlantViewModel(plantEntity);
                }

            }
            _plants.ObserveAdd().Subscribe(e =>
            {
                CreatePlantViewModel(e.Value);
            });

            _plants.ObserveRemove().Subscribe(e =>
            {
                RemovePlantViewModel(e.Value);
            });
        }
        public bool PlacePlant(int level, int cellId)
        {
            var parameters = new CmdPlacePlantParameters(level, cellId);
            CommandResult<PlantEntity> result = _cmd.Process<CmdPlacePlantParameters, PlantEntity>(parameters);
            _plants.Add(result.Result);

            return result.Success;
        }
        private void CreatePlantViewModel(PlantEntity plantEntity)
        {
            PlantAvatarConfig config = _plantsConfigs[plantEntity.Level.Value];
            var plantViewModel = new PlantViewModel(plantEntity, config, this);
            _plantsMap.Add(plantEntity.UniqueId, plantViewModel);
            _allPlants.Add(plantViewModel);
        }

        private void RemovePlantViewModel(PlantEntity plantEntity)
        {
            if (_plantsMap.TryGetValue(plantEntity.UniqueId, out var plantViewModel))
            {
                _allPlants.Remove(plantViewModel);
                _plantsMap.Remove(plantEntity.UniqueId);
            }
        }

        public void TryMergePlants(int firstPlantId, int secondPlantId)
        {
            PlantEntity firstPlant = _plants.FirstOrDefault(p => p.UniqueId == firstPlantId);
            _plants.Remove(firstPlant);

            var parameters1 = new CmdDeletePlantParameters(firstPlant);
            bool result1 = _cmd.Process(parameters1);

            PlantEntity secondPlant = _plants.FirstOrDefault(p => p.UniqueId == secondPlantId);
            int cellId = secondPlant.CellId.Value;
            int level = secondPlant.Level.Value + 1;
            _plants.Remove(secondPlant);

            var parameters2 = new CmdDeletePlantParameters(secondPlant);
            bool result2 = _cmd.Process(parameters2);

            PlacePlant(level, cellId);

        }

    }
}
