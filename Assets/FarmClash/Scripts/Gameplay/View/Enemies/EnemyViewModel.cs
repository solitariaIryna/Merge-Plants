using MergePlants.Configs.Enemies;
using MergePlants.Gameplay.Services;
using MergePlants.State.Entities.Enemies;

namespace MergePlants.Gameplay.View.Enemies
{
    public class EnemyViewModel
    {
        public readonly EnemyAvatarConfig Config;
        public readonly int EntityId;
        private EnemiesService _enemiesService;

        public EnemyViewModel(EnemyEntity enemyEntity, EnemyAvatarConfig config, EnemiesService enemiesService)
        {
            Config = config;
            EntityId = enemyEntity.UniqueId;
            _enemiesService = enemiesService;
        }
    }
}
