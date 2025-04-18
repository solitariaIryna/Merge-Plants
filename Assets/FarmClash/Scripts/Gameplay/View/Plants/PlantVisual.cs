using MergePlants.Configs.Plants;
using MergePlants.Configs.Visual;
using UnityEngine;

namespace MergePlants.Gameplay.View.Plants
{
    public class PlantVisual : MonoBehaviour
    {
        [SerializeField] private AnimationConfig _config;
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _renderer;

        private PlantVisualConfig _visualConfig;

        public void Construct(PlantVisualConfig visualConfig)
        {
            _visualConfig = visualConfig;
            _renderer.sprite = _visualConfig.Sprite;
        }
    }
}
