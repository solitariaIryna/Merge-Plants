using System;
using UnityEditor.Animations;
using UnityEngine;

namespace MergePlants.Configs.Plants
{
    [Serializable]
    public class PlantVisualConfig
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public AnimatorController AnimatorController { get; private set; }
    }

}
