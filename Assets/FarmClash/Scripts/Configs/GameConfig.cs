using MergePlants.Configs.Enemies;
using MergePlants.Configs.Levels;
using MergePlants.Configs.Plants;
using UnityEngine;

namespace MergePlants.Configs
{
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = "Configs/New " + nameof(GameConfig))]
    public class GameConfig : ScriptableObject
    {
        public LevelsConfigs LevelsConfigs;
        public PlantsConfigs PlantsConfigs;
        public EnemiesConfigs EnemiesConfigs;

    }
}
