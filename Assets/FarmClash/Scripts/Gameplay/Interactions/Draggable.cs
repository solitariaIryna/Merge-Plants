using UnityEngine;

namespace MergePlants.Gameplay.Interactions
{
    public class Draggable : MonoBehaviour, IInteractable
    {
        [SerializeField] private float _moveSpeed = 10;
        [field: SerializeField] public bool CanInteract { get; private set; } = true;
        public Vector3 Position => transform.position;


        private bool _isHolded;
        private Vector3 _targetPosition;
        public void SelectionStarted(Vector2 position)
        {
            if (!CanInteract)
                return;

            _targetPosition = new Vector3(position.x, position.y, transform.position.z);
            _isHolded = true;

            OnSelectionStarted(position);

        }
        public void SelectionHolded(Vector2 position)
        {
            if (!_isHolded)
                return;

            _targetPosition = new Vector3(position.x, position.y, transform.position.z);

            OnSelectionHolded(position);
        }
        public void SelectionEnded(Vector3 position)
        {
            if (!_isHolded)
                return;

            _targetPosition = new Vector3(position.x, position.y, transform.position.z);
            _isHolded = false;

            OnSelectionEnded(position);
        }
        private void Update()
        {
            if (_isHolded)
                MoveToHoldedPosition();

            OnUpdate();
        }
        private void MoveToHoldedPosition()
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
            transform.position = newPosition;
        }
        public virtual void OnSelectionStarted(Vector3 position) { }
        public virtual void OnSelectionHolded(Vector2 position) { }
        public virtual void OnSelectionEnded(Vector3 position) { }
        public virtual void OnUpdate() { }

    }
}
