using MergePlants.Configs.Enemies;
using MergePlants.Configs.Visual;
using MergePlants.Gameplay.Core;
using MergePlants.Gameplay.Enemies;
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
        private void Start()
        {
            _enemy.Damagable.Died += PlayDieAnimation;
            _enemy.Hit += PlayHitAnimation;
        }

        private void PlayHitAnimation()
        {
            _animator.SetTrigger(_animationConfig.HitTrigger);
        }

        private void OnDisable()
        {
            _enemy.Damagable.Died -= PlayDieAnimation;
            _enemy.Hit -= PlayHitAnimation;
        }

        private void PlayDieAnimation(IDamagable damagable)
        {
            _animator.SetTrigger(_animationConfig.DieTrigger);
        }

        private void Update()
        {
            _animator.SetFloat(_animationConfig.MoveSpeed, _enemy.Mover.Velocity.magnitude);
        }
    }
}
