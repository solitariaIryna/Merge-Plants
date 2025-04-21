using System;
using UnityEditor.Animations;
using UnityEngine;

namespace MergePlants.Configs.Enemies
{
    [Serializable]
    public class EnemyVisualConfig
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public AnimatorController AnimatorController { get; private set; }
    }
}
