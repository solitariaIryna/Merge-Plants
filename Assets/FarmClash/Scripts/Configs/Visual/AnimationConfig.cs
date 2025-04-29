using UnityEngine;

namespace MergePlants.Configs.Visual
{
    [CreateAssetMenu(fileName = nameof(AnimationConfig), menuName = "Configs/Visual/" + nameof(AnimationConfig))]
    public class AnimationConfig : ScriptableObject
    {
        [Header("Animation Triggers")]
        [SerializeField] private string _deadStateTrigger = "Dead";
        [SerializeField] private string _hitStateTrigger = "Hit";

        [Header("Animation Values")]
        [SerializeField] private string _moveSpeed = "Move Speed";

        public int MoveSpeed { get; private set; }
        public int DieTrigger { get; private set; }
        public int HitTrigger { get; private set; }

        private void OnValidate()
        {
            MoveSpeed = Animator.StringToHash(_moveSpeed);
            DieTrigger = Animator.StringToHash(_deadStateTrigger);
            HitTrigger = Animator.StringToHash(_hitStateTrigger);
        }
    }
}
