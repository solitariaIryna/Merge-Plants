using MergePlants.Services.Command;
using MergePlants.State.Entities.Plants;
using MergePlants.Gameplay.Commands.Parameters;
using ObservableCollections;
using System.Collections.Generic;
using MergePlants.Services.SaveLoad;
using MergePlants.State.Entities;
using MergePlants.Configs.Plants;
using MergePlants.Services.ConfigsProvider;
using System.Linq;

namespace MergePlants.Gameplay.Services
{
    public class PlantsService
    {
        public IObservableCollection<PlantEntity> AllPlants => _allPlants;

        private readonly ObservableList<PlantEntity> _allPlants = new();
        private readonly Dictionary<int, PlantAvatarConfig> _plantsConfigs = new();
        private readonly Dictionary<int, PlantEntity> _plantsMap = new();
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
                    {
                        _allPlants.Add(plantEntity);
                        _plantsMap[plantEntity.Level] = plantEntity;
                    }
                        
                }

            }

        }
        public bool PlacePlant(int level, int cellId)
        {
            var parameters = new CmdPlacePlantParameters(level, cellId);
            CommandResult<PlantEntity> result = _cmd.Process<CmdPlacePlantParameters, PlantEntity>(parameters);
            _allPlants.Add(result.Result);

            return result.Success;
        }

        public void TryMergePlants(int firstPlantId, int secondPlantId)
        {
            PlantEntity firstPlant = _allPlants.FirstOrDefault(p => p.UniqueId == firstPlantId);
            _allPlants.Remove(firstPlant);

            var parameters1 = new CmdDeletePlantParameters(firstPlant);
            bool result1 = _cmd.Process(parameters1);

            PlantEntity secondPlant = _allPlants.FirstOrDefault(p => p.UniqueId == secondPlantId);
            int cellId = secondPlant.CellId.Value;
            int level = secondPlant.Level + 1;
            _allPlants.Remove(secondPlant);

            var parameters2 = new CmdDeletePlantParameters(secondPlant);
            bool result2 = _cmd.Process(parameters2);

            PlacePlant(level, cellId);

        }

        public PlantAvatarConfig GetConfigForLevel(int level)
        {
            return _plantsConfigs[level];
        }
    }
}
