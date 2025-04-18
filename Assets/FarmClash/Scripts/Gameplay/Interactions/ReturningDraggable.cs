using DG.Tweening;
using UnityEngine;

namespace MergePlants.Gameplay.Interactions
{
    public class ReturningDraggable : Draggable
    {
        [field: SerializeField] public bool CanReturn { get; private set; } = true;
        private Vector3 _startPosition; 
        public override void OnSelectionStarted(Vector3 position)
        {
            base.OnSelectionStarted(position);
            _startPosition = transform.position;
        }

        public override void OnSelectionEnded(Vector3 position)
        {
            base.OnSelectionEnded(position);

            if (CanReturn)
            {
                transform.DOMove(_startPosition, 0.2f)
                    .SetEase(Ease.InBack);
            }
        }
    }


}
