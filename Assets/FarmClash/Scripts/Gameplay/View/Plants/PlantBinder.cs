using MergePlants.Gameplay.Interactions;
using MergePlants.State.Entities;
using UnityEngine;

namespace MergePlants.Gameplay.View.Plants
{
    public class PlantBinder : ReturningDraggable, IMergable
    {
        [field: SerializeField] public PlantVisual Visual { get; private set; }

        public EntityType Type => _plantViewModel.Type;
        public int Level => _plantViewModel.Level.Value;

        public int EntityId => _plantViewModel.EntityId;

        private PlantViewModel _plantViewModel;
        public void Bind(PlantViewModel viewModel)
        {
            _plantViewModel = viewModel;
            transform.position = _plantViewModel.Position.Value;
        }

        public override void OnSelectionEnded(Vector3 position)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(position, Vector2.zero, 1);

            bool hasMergable = false;

            if (hits.Length > 0)
            {
                foreach (RaycastHit2D hit in hits)
                {
                    if (hit.collider.gameObject == gameObject)
                        continue;

                    if (hit.collider.TryGetComponent<IMergable>(out IMergable mergable))
                    {
                        hasMergable = _plantViewModel.TryRequestMerge(mergable);
                        break;
                    }
                }
                if (!hasMergable)
                    base.OnSelectionEnded(position);
            }
            else
                base.OnSelectionEnded(position);
        }
    }
    public interface IMergable
    {
        EntityType Type { get; }
        int EntityId { get; }
        int Level { get; }
    }
}
