using UnityEngine;

namespace FarmClash.Configs.Levels
{
    [CreateAssetMenu(fileName = nameof(LevelConfig), menuName = "Configs/Levels/" + nameof(LevelConfig))]
    public class LevelConfig : ScriptableObject
    {
        public int LevelId;

    }

}
