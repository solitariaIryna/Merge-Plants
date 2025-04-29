using MergePlants.Gameplay.Core;
using MergePlants.Gameplay.Interactions;
using MergePlants.Gameplay.Services;
using MergePlants.Gameplay.View.Plants;
using MergePlants.State.Entities.Plants;
using MergePlants.State.Entities;
using R3;
using UnityEngine;
using Zenject;
using MergePlants.Gameplay.Enemies;

namespace MergePlants.Gameplay.Plants
{
    public class PlantEntity : MergableEntity
    {
        [field: SerializeField] public PlantVisual Visual { get; private set; }
        [SerializeField] private ReturningDraggable _draggable;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private TriggerObserver _attackObserver;

        public ReactiveProperty<int> CellId { get; } = new();

        private PlantAttacker _attacker;
        private PlantsService _plantsService;
        private PlantEntityData _data;

        [Inject]
        private void Construct(PlantsService plantsService, BulletService bulletService)
        {
            _plantsService = plantsService;
            _attacker = new PlantAttacker(bulletService, _attackPoint);
        }

        public void SetData(PlantEntityData data)
        {
            base.SetData(data);
            _data = data;

            CellId.Value = data.CellId;
            CellId.Subscribe(id => data.CellId = id);
            transform.position = data.Position;
            Visual.Construct(data.Config.VisualConfig);
            _attacker.SetConfig(data.Config.Config);
        }

        private void OnEnable()
        {
            _draggable.OnSelectionEnded += OnSelectionEnded;
            _attackObserver.TriggerEntered += TriggerEntered;
            _attackObserver.TriggerExited += TriggerExited;
        }

        private void OnDisable()
        {
            _draggable.OnSelectionEnded -= OnSelectionEnded;
            _attackObserver.TriggerEntered -= TriggerEntered;
            _attackObserver.TriggerExited -= TriggerExited;
        }

        private void TriggerEntered(Collider2D collider)
        {
            if (collider.TryGetComponent<IDamagableTarget>(out var target))
                _attacker.StartAttacking(target);
        }

        private void TriggerExited(Collider2D collider)
        {
            if (collider.TryGetComponent<IDamagableTarget>(out var target))
                _attacker.StopAttacking(target);
        }

        private void OnSelectionEnded(Vector3 position)
        {
            foreach (var hit in Physics2D.RaycastAll(position, Vector2.zero, 1))
            {
                if (hit.collider.gameObject == gameObject) continue;
                if (hit.collider.TryGetComponent<IMergable>(out var mergable))
                {
                    if (TryRequestMerge(mergable)) return;
                }
            }

            _draggable.Return();
        }

        private bool TryRequestMerge(IMergable other)
        {
            if (other.Type == Type && other.Level == Level)
            {
                _plantsService.TryMergePlants(UniqueId, other.UniqueId);
                return true;
            }

            return false;
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }

}
