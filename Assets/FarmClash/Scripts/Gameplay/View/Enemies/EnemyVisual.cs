using MergePlants.Configs.Enemies;
using MergePlants.Configs.Visual;
using UnityEngine;

namespace MergePlants.Gameplay.View.Enemies
{
    public class EnemyVisual : MonoBehaviour
    {
        [SerializeField] private AnimationConfig _animationConfig;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Animator _animator;

        private EnemyVisualConfig _visualConfig;
        public void Construct(EnemyVisualConfig visualConfig)
        {
            _visualConfig = visualConfig;
            _renderer.sprite = _visualConfig.Sprite;
        }
    }
}
