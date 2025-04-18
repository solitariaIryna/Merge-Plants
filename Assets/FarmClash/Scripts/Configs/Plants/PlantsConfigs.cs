using UnityEngine;

namespace MergePlants.Configs.Plants
{
    [CreateAssetMenu(fileName = nameof(PlantsConfigs), menuName = "Configs/Gameplay/Plants/" + nameof(PlantsConfigs))]
    public class PlantsConfigs : ScriptableObject
    {
        [field: SerializeField] public PlantAvatarConfig[] Plants { get; private set; }
    }

}
