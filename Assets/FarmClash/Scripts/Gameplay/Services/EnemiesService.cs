using MergePlants.Configs.Enemies;
using MergePlants.Gameplay.Commands.Parameters;
using MergePlants.Services.Command;
using MergePlants.Services.ConfigsProvider;
using ObservableCollections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MergePlants.Gameplay.View.Levels;
using MergePlants.Gameplay.Enemies;

namespace MergePlants.Gameplay.Services
{
    public class EnemiesService
    {
        public IObservableCollection<EnemyEntity> AllEnemies => _allEnemies;
        private Dictionary<EnemyType, EnemyAvatarConfig> _enemiesConfigs;

        private readonly ObservableList<EnemyEntity> _allEnemies = new();
        private readonly Dictionary<int, EnemyEntity> _enemiesMap = new();
        private readonly ICommandProcessor _cmd;

        public EnemiesService(ICommandProcessor cmd, IConfigsProvider configsProvider)
        {
            _cmd = cmd;

            _enemiesConfigs = configsProvider
                .GameConfig
                .EnemiesConfigs
                .Enemies
                .ToDictionary(e => e.Config.Type);

        }

        public bool CreateEnemy(EnemyType enemyType, Vector3 position, EnemyPath path)
        {
            var parameters = new CmdCreateEnemyParameters(enemyType, position, path);
            CommandResult<EnemyEntity> result = _cmd.Process<CmdCreateEnemyParameters, EnemyEntity>(parameters);
            _allEnemies.Add(result.Result);
            _enemiesMap[result.Result.UniqueId] = result.Result;

            return result.Success;
        }

        public EnemyAvatarConfig GetConfigForType(EnemyType type)
        {
            return _enemiesConfigs[type];
        }
    }
}
