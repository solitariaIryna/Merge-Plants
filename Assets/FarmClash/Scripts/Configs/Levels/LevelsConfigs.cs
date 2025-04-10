using System.Collections.Generic;
using UnityEngine;

namespace FarmClash.Configs.Levels
{
    [CreateAssetMenu(fileName = nameof(LevelsConfigs), menuName = "Configs/Levels/" + nameof(LevelsConfigs))]
    public class LevelsConfigs : ScriptableObject
    {
        [field: SerializeField] public List<LevelConfig> Levels { get; private set; }

    }

}
