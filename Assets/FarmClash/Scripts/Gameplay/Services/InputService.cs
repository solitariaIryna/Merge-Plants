using MergePlants.Gameplay.Interactions;
using System.Collections.Generic;
using UnityEngine;

namespace MergePlants.Gameplay.Services
{
    public class InputService : MonoBehaviour
    {
        [SerializeField] private LayerMask _clickLayer;
        [SerializeField] private Camera _camera;

        private readonly List<IInteractable> _interactables = new();

        private bool _isClicking;

        private void Update()
        {
            if (_camera == null)
                return;

            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                _isClicking = true;
                HandleSelectionStarted(mousePosition);
            }

            if (Input.GetMouseButton(0) && _isClicking)
            {
                HandleSelectionHeld(mousePosition);
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (_isClicking)
                {
                    HandleSelectionEnded(mousePosition);
                    _isClicking = false;
                }
            }
        }

        private void HandleSelectionStarted(Vector2 position)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(position, Vector2.zero, _clickLayer);

            _interactables.Clear();

         //   foreach (RaycastHit2D hit in hits)
        //    {
                if (hits.Length > 0 && hits[0].collider.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    //foreach (var interactable in hit.collider.GetComponents<IInteractable>())
                    //{
                        _interactables.Add(interactable);
                        interactable.SelectionStarted(position);
                  //  }
                }
       //     }
        }
        private void HandleSelectionHeld(Vector2 position)
        {
            foreach (var interactable in _interactables)
            {
                interactable.SelectionHolded(position);
            }
        }

        private void HandleSelectionEnded(Vector2 position)
        {
            foreach (var interactable in _interactables)
            {
                interactable.SelectionEnded(position);
            }

            _interactables.Clear();
        }
    
    }
   
}
