using MergePlants.Gameplay.Interactable;
using R3;
using UnityEngine;

namespace MergerPlants.Gameplay.View.Draggable
{
    public abstract class DraggableBinder : MonoBehaviour, IInteractable
    {
        public Vector3 Position => transform.position;

        public bool CanInteract => _draggableViewModel.CanInteract.Value;

        protected DraggableViewModel _draggableViewModel;

        private bool _isHolded;
        public virtual void Bind(DraggableViewModel viewModel)
        {
            _draggableViewModel = viewModel;

            _draggableViewModel.Position.Subscribe(pos => transform.position = pos);
        }

        public void SelectionStarted(Vector2 position)
        {
            if (!CanInteract)
                return;

            _draggableViewModel.TargetPosition = new Vector3(position.x, position.y, transform.position.z);
            _isHolded = true;

        }
        public void SelectionHolded(Vector2 position)
        {
            if (!_isHolded)
                return;

            _draggableViewModel.TargetPosition = new Vector3(position.x, position.y, transform.position.z);

            OnSelectionHolded(position);
        }
        public void SelectionEnded(Vector3 position)
        {
            if (!_isHolded)
                return;

            _draggableViewModel.TargetPosition = new Vector3(position.x, position.y, transform.position.z);
            _isHolded = false;

            OnSelectionEnded(position);
        }
        private void Update()
        {
            if (_isHolded)
                _draggableViewModel.Update();

            OnUpdate();
        }

        public virtual void OnSelectionStarted(Vector3 position) { }
        public virtual void OnSelectionHolded(Vector2 position) { }
        public virtual void OnSelectionEnded(Vector3 position) { }
        public virtual void OnUpdate() { }

    }
}
