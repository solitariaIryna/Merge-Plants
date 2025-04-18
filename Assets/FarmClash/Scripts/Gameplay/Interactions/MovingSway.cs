
using MergePlants.Gameplay.Core;
using UnityEngine;

namespace MergePlants.Gameplay.Interactions
{
    public class MovingSway : MonoInitializeable
    {
        [SerializeField] private Transform _target;
        [Header("Moving")]
        [SerializeField] private Vector3 _deltaMultiplyers = new Vector3(20f, 0f, 30f);
        [SerializeField] private float _smoothDelta;
        [SerializeField] private float _fakeTargetSpeed;
        [SerializeField] private float _realSpeed;
        [Header("Static")]
        [SerializeField] private float _restoreRotationTime = 0.3f;
        [SerializeField] private AnimationCurve _restorationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        private Vector3 _moveDelta;

        private Quaternion _startRotation;

        private Vector3 _currentNewRotation;
        private Vector3 _velocity;
        private Quaternion _fakeTarget;

        private Quaternion _startStaticRotation;
        private float _staticPassedTime;

        private bool _restortaionStarted;

        private Vector3 _lastPosition;

        public Vector3 MoveDelta => _moveDelta;

        public Transform Target { get => _target; set => _target = value; }

        protected override void OnInitialize()
        {
            _startRotation = _target.localRotation;
            _fakeTarget = _startRotation;

            _lastPosition = transform.position;
        }

        public void Update()
        {
            Vector3 newPosition = transform.position;

            if (newPosition != _lastPosition)
                UpdateSway(newPosition);
            else if (_staticPassedTime <= _restoreRotationTime)
                UpdateRestoration();
        }

        public void ResetSway()
        {
            _fakeTarget = _startRotation;
            _lastPosition = transform.position;

            _restortaionStarted = false;
            _staticPassedTime = _restoreRotationTime;
        }

        private void UpdateSway(Vector3 newPosition)
        {
            float deltaTime = Time.deltaTime;

            _moveDelta = (newPosition - _lastPosition) / deltaTime;

            Vector3 newRotation = new Vector3(-_moveDelta.y * _deltaMultiplyers.x, 0f, -_moveDelta.x * _deltaMultiplyers.z);

            _currentNewRotation = Vector3.SmoothDamp(_currentNewRotation, newRotation, ref _velocity, _smoothDelta);

            Quaternion targetRotation = _startRotation * Quaternion.Euler(_currentNewRotation);

            _fakeTarget = Quaternion.RotateTowards(_fakeTarget, targetRotation, _fakeTargetSpeed * deltaTime);

            _target.localRotation = Quaternion.Lerp(_target.localRotation, _fakeTarget, _realSpeed * deltaTime);

            _staticPassedTime = 0f;
            _restortaionStarted = false;

            _lastPosition = newPosition;
        }

        private void UpdateRestoration()
        {
            if (_restortaionStarted == false)
            {
                _restortaionStarted = true;

                _startStaticRotation = _target.localRotation;

                _currentNewRotation = Vector3.zero;
                _velocity = Vector3.zero;
                _fakeTarget = _startRotation;
            }

            _staticPassedTime += Time.deltaTime;

            float t = _staticPassedTime / _restoreRotationTime;

            _target.localRotation = Quaternion.Lerp(_startStaticRotation, _startRotation, _restorationCurve.Evaluate(t));
        }
    }
}
