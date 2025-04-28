using MergePlants.Configs.Enemies;
using MergePlants.Configs.Visual;
using MergePlants.State.Entities.Enemies;
using UnityEngine;

namespace MergePlants.Gameplay.View.Enemies
{
    public class EnemyVisual : MonoBehaviour
    {
        [SerializeField] private EnemyEntity _enemy;
        [SerializeField] private AnimationConfig _animationConfig;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Animator _animator;

        private EnemyVisualConfig _visualConfig;
        public void Construct(EnemyVisualConfig visualConfig)
        {
            _visualConfig = visualConfig;
            _renderer.sprite = _visualConfig.Sprite;
            _animator.runtimeAnimatorController = _visualConfig.AnimatorController;

            
        }

        private void Update()
        {
            _animator.SetFloat(_animationConfig.MoveSpeed, _enemy.Velocity);
        }
    }
}
