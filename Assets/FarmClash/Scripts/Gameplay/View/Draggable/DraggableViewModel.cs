using DG.Tweening;
using R3;
using UnityEngine;

namespace MergerPlants.Gameplay.View.Draggable
{
    public abstract class DraggableViewModel
    {
        public ReactiveProperty<bool> CanInteract { get; }

        public ReactiveProperty<Vector3> Position { get; private set; }

        public Vector3 TargetPosition;

        private float _moveSpeed = 3;

        public void Update()
        {
            MoveToHoldedPosition();
        }
        private void MoveToHoldedPosition()
        {
            Vector3 newPosition = Vector3.Lerp(Position.Value, TargetPosition, _moveSpeed * Time.deltaTime);
            Position.Value = newPosition;
        }
    }
    public abstract class ReturningDraggableViewModel : DraggableViewModel
    {
        public ReactiveProperty<bool> CanReturn { get; } = new(true);
        public Vector3 StartPosition { get; private set; }

        public void SaveStartPosition()
        {
            StartPosition = Position.Value;
        }
    }

    public abstract class ReturningDraggableBinder : DraggableBinder
    {
        protected new ReturningDraggableViewModel _draggableViewModel;

        public override void Bind(DraggableViewModel viewModel)
        {
            base.Bind(viewModel);
            _draggableViewModel = viewModel as ReturningDraggableViewModel;
        }

        public override void OnSelectionStarted(Vector3 position)
        {
            base.OnSelectionStarted(position);
            _draggableViewModel?.SaveStartPosition();
        }

        public override void OnSelectionEnded(Vector3 position)
        {
            base.OnSelectionEnded(position);

            if (_draggableViewModel == null)
                return;

            if (_draggableViewModel.CanReturn.Value)
            {
                transform.DOMove(_draggableViewModel.StartPosition, 0.2f)
                    .SetEase(Ease.InBack)
                    .OnComplete(() =>
                    {
                        _draggableViewModel.Position.Value = transform.position;
                    });
            }
        }
    }


}
