using UnityEngine;

namespace MergePlants.Configs.Enemies
{
    [CreateAssetMenu(fileName = nameof(EnemiesWaveConfig), menuName = "Configs/Gameplay/Waves/" + nameof(EnemiesWaveConfig))]
    public class EnemiesWaveConfig : ScriptableObject
    {
        [field: SerializeField] public int SpawnDelay { get; private set; }
        [field: SerializeField] public EnemiesQueque[] EnemiesQueues { get; private set; }
    }
}
