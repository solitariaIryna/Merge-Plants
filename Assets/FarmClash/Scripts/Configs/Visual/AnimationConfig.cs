using UnityEngine;

namespace MergePlants.Configs.Visual
{
    [CreateAssetMenu(fileName = nameof(AnimationConfig), menuName = "Configs/Visual/" + nameof(AnimationConfig))]
    public class AnimationConfig : ScriptableObject
    {
        [Header("Animation Triggers")]
        public string DeadStateTrigger = "Dead";
    }
}
