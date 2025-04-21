using UnityEngine;

namespace MergePlants.Configs.Enemies
{
    [CreateAssetMenu(fileName = nameof(EnemiesConfigs), menuName = "Configs/Gameplay/Enemies/" + nameof(EnemiesConfigs))]
    public class EnemiesConfigs : ScriptableObject
    {
        [field: SerializeField] public EnemyAvatarConfig[] Enemies { get; private set; }

    }
}
