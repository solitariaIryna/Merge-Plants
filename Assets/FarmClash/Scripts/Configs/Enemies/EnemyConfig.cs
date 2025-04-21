using System;
using UnityEngine;

namespace MergePlants.Configs.Enemies
{
    [Serializable]
    public class EnemyConfig
    {
        [field: SerializeField] public string ConfigId { get; private set; }
        [field: SerializeField] public string DisplayName { get; private set; }
        [field: SerializeField] public EnemyType Type { get; private set; }

        [Header("Stats")]
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float AttackInterval { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }

        [Header("Rewards")]
        [field: SerializeField] public int RewardCoins { get; private set; }
        [field: SerializeField] public int RewardXP { get; private set; }

        [Header("Economy")]
        [field: SerializeField] public int Cost { get; private set; }

    }
}
