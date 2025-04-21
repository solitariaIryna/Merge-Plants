using MergePlants.Configs.Enemies;
using MergePlants.Gameplay.Commands.Parameters;
using MergePlants.Gameplay.View.Enemies;
using MergePlants.Services.Command;
using MergePlants.Services.ConfigsProvider;
using MergePlants.State.Entities.Enemies;
using ObservableCollections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using R3;
using MergePlants.Gameplay.View.Levels;

namespace MergePlants.Gameplay.Services
{
    public class EnemiesService
    {
        public IObservableCollection<EnemyViewModel> AllEnemies => _allEnemies;
        private Dictionary<EnemyType, EnemyAvatarConfig> _enemiesConfigs;

        private ObservableList<EnemyEntity> _enemies = new();
        private readonly ObservableList<EnemyViewModel> _allEnemies = new();
        private readonly Dictionary<int, EnemyViewModel> _enemiesMap = new();
        private readonly ICommandProcessor _cmd;

        public EnemiesService(ICommandProcessor cmd, IConfigsProvider configsProvider)
        {
            _cmd = cmd;

            _enemiesConfigs = configsProvider
                .GameConfig
                .EnemiesConfigs
                .Enemies
                .ToDictionary(e => e.Config.Type);

            _enemies.ObserveAdd().Subscribe(e =>
            {
                CreateEnemyViewModel(e.Value);
            });
            _enemies.ObserveRemove().Subscribe(e =>
            {
                RemoveEnemyViewModel(e.Value);
            });
        }

        public bool CreateEnemy(EnemyType enemyType, Vector3 position, EnemyPath path)
        {
            var parameters = new CmdCreateEnemyParameters(enemyType, position, path);
            CommandResult<EnemyEntity> result = _cmd.Process<CmdCreateEnemyParameters, EnemyEntity>(parameters);
            _enemies.Add(result.Result);

            return result.Success;
        }
        private void CreateEnemyViewModel(EnemyEntity enemyEntity)
        {
            EnemyAvatarConfig config = _enemiesConfigs[enemyEntity.EnemyType];
            var enemyViewModel = new EnemyViewModel(enemyEntity, config, this);
            _enemiesMap.Add(enemyEntity.UniqueId, enemyViewModel);
            _allEnemies.Add(enemyViewModel);
        }
        private void RemoveEnemyViewModel(EnemyEntity enemyEntity)
        {
            if (_enemiesMap.TryGetValue(enemyEntity.UniqueId, out var enemyViewModel))
            {
                _allEnemies.Remove(enemyViewModel);
                _enemiesMap.Remove(enemyEntity.UniqueId);
            }
        }


    }
}
