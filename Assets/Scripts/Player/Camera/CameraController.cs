using UnityEngine;

namespace Player.Camera
{
    class CameraController : MonoBehaviour, ICameraController
    {
        [SerializeField] private float _minDistance;
        [SerializeField] private float _maxDistance;

        private Vector3 _offsetDirection;
        private float _oldDistance;

        private void Awake()
        {
            _offsetDirection = transform.localPosition.normalized;
        }

        public void Zoom(float speedFactor)
        {
            float distance = _minDistance + (_maxDistance - _minDistance) * speedFactor;
            transform.localPosition = _offsetDirection * Mathf.Lerp(distance, _oldDistance, 0.1f);
            transform.LookAt(PlayerController.Instance.Self);
            _oldDistance = distance;
        }
    }
}