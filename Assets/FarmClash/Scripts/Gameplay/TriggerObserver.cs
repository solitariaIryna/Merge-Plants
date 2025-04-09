using System;
using UnityEngine;

namespace Assets.FarmClash.Scripts.Gameplay
{
    public class TriggerObserver : MonoBehaviour
    {
        public Action<Collider> TriggerEntered;
        public Action<Collider> TriggerExited;
        private void OnTriggerEnter(Collider other)
        {
            TriggerEntered?.Invoke(other);
        }
        private void OnTriggerExit(Collider other)
        {
            TriggerExited?.Invoke(other);
        }
    }
}
