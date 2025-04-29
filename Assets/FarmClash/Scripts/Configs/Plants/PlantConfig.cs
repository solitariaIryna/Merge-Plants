using System;
using UnityEngine;

namespace MergePlants.Configs.Plants
{
    [Serializable]
    public class PlantConfig
    {
        [field: SerializeField] public string ConfigId { get; private set; }
        [field: SerializeField] public string DisplayName { get; private set; }

        [Header("Combat")]
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float AttackSpeed { get; private set; }
        [field: SerializeField] public float BulletSpeed { get; private set; }
        [field: SerializeField] public float Range { get; private set; }
        [field: SerializeField] public DamageType DamageType { get; private set; }

        [Header("Merge")]
        [field: SerializeField] public int Level { get; private set; }

        [Header("Economy")]
        [field: SerializeField] public int Cost { get; private set; }
    }

}
