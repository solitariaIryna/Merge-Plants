using DG.Tweening;
using UnityEngine;

namespace MergePlants.Gameplay.Interactions
{
    public class ReturningDraggable : Draggable
    {
        [field: SerializeField] public bool CanReturn { get; private set; } = true;
        private Vector3 _startPosition;
        public override void SelectionStarted(Vector2 position)
        {
            base.SelectionStarted(position);
            _startPosition = transform.position;
        }
        public void Return()
        {
            if (CanReturn)
            {
                transform.DOMove(_startPosition, 0.2f)
                    .SetEase(Ease.InBack);
            }
        }
    }


}
