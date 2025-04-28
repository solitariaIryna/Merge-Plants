using MergePlants.Gameplay.Core;
using MergePlants.Gameplay.Interactions;
using MergePlants.Gameplay.Services;
using MergePlants.Gameplay.View.Plants;
using R3;
using System.Collections;
using UnityEngine;
using Zenject;

namespace MergePlants.State.Entities.Plants
{
    public class PlantEntity : MergableEntity
    {
        [field: SerializeField] public PlantVisual Visual { get; private set; }
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private ReturningDraggable _draggable;
        [SerializeField] private TriggerObserver _attackObserver;

        public ReactiveProperty<int> CellId = new();

        private PlantsService _plantsService;
        private BulletService _bulletService;

        private PlantEntityData _plantData;
        private IDamagable _attackTarget;

        private Coroutine _attackingCoroutine;

        [Inject]
        private void Construct(PlantsService plantsService, BulletService bulletService)
        {
            _plantsService = plantsService;
            _bulletService = bulletService;

        }
        public void SetData(PlantEntityData data) 
        {
            base.SetData(data);
            _plantData = data;
            CellId.Value = data.CellId;

            CellId.Subscribe(c => data.CellId = c);
            transform.position = data.Position;

            Visual.Construct(data.Config.VisualConfig);
        }
        private void OnEnable()
        {
            _draggable.OnSelectionEnded += OnSelectionEnded;
            _attackObserver.TriggerEntered += StartAttack;
            _attackObserver.TriggerExited += StopAttack; 
        }

        private void StopAttack(Collider2D collider)
        {
            if (collider.transform == _attackTarget.Transform)
                _attackTarget = null;
            
        }

        private void StartAttack(Collider2D collider)
        {
            if (collider.TryGetComponent<IDamagable>(out IDamagable damagableTarget))
            {
                _attackTarget = damagableTarget;

                if (_attackingCoroutine == null)
                {
                    StartCoroutine(Attacking());
                }
            }
        }
        private IEnumerator Attacking()
        {
            while (_attackTarget != null && _attackTarget.IsAlive)
            {
                yield return new WaitForSeconds(_plantData.Config.Config.AttackSpeed);
                _bulletService.CreateBullet(_attackPoint.position, _attackTarget.Transform);
            }
        }
        private void OnDisable()
        {
            _draggable.OnSelectionEnded -= OnSelectionEnded;
            _attackObserver.TriggerEntered -= StartAttack;
            _attackObserver.TriggerExited -= StopAttack;
        }

        public void OnSelectionEnded(Vector3 position)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(position, Vector2.zero, 1);

            bool hasMerge = false;

            if (hits.Length > 0)
            {
                foreach (RaycastHit2D hit in hits)
                {
                    if (hit.collider.gameObject == gameObject)
                        continue;

                    if (hit.collider.TryGetComponent<IMergable>(out IMergable mergable))
                    {
                        hasMerge = TryRequestMerge(mergable);
                        break;
                    }
                }            
            }
            
            if (!hasMerge)
                _draggable.Return();
        }
        public bool TryRequestMerge(IMergable other)
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
