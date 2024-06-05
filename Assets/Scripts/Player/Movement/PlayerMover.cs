using UnityEngine;

namespace Player.Movement
{
    public class PlayerMover : MonoBehaviour, IMover
    {
        [SerializeField] private float _acceleration = 20;
        [SerializeField] private float _friction = 10;
        [SerializeField] private float _maxSpeed = 40;
        [SerializeField] private float _rotationSpeed = 120;
        [SerializeField] private float _inertiaFactor = 1;

        private Transform _movable;
        private Transform _model;
        private float _velocity = 0;
        private Vector3 _oldVelocity3d;
        private Vector3 _newVelocity3d;

        public float RelativeSpeed => Mathf.Abs(_velocity) / _maxSpeed;

        public void Init(IMovable movable)
        {
            _movable = movable.Self;
            _model = movable.Model;
        }

        public void Move(float input, float deltaTime)
        {
            _oldVelocity3d = _newVelocity3d;
            var friction = Mathf.Clamp(_friction * deltaTime, 0, Mathf.Abs(_velocity));
            _velocity += -Mathf.Sign(_velocity) * friction;

            var acceleration = input * _acceleration * deltaTime;
            if (input > 0 && _velocity < _maxSpeed)
                acceleration = Mathf.Clamp(acceleration, 0, _maxSpeed - _velocity);
            else if (input < 0 && _velocity > -_maxSpeed)
                acceleration = Mathf.Clamp(acceleration, -_maxSpeed - _velocity , 0);
            _velocity += acceleration;
            
            if (input == 0 && Mathf.Abs(_velocity) < 0.01f)
                _velocity = 0;

            _newVelocity3d = _movable.forward * _velocity;
            if (_velocity != 0)
                _movable.Translate(_newVelocity3d * deltaTime, Space.World);
        }

        public void Rotate(float input, float deltaTime)
        {
            _movable.Rotate(Vector3.up, input * Mathf.Sign(_velocity) * deltaTime * _rotationSpeed);

            Vector3 deltaVelocity = _newVelocity3d - _oldVelocity3d;
            var internalDelta = _movable.InverseTransformDirection(deltaVelocity);
            
            var targetRot = Quaternion.Euler(-internalDelta.z * _inertiaFactor, 0, internalDelta.x * _inertiaFactor);
            _model.localRotation = Quaternion.Slerp(_model.localRotation , targetRot, 0.1f);
            
        }
    }
}