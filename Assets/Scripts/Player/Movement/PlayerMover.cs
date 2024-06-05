using UnityEngine;

namespace Player.Movement
{
    public class PlayerMover : MonoBehaviour, IMover
    {
        [SerializeField] private float Speed = 20;
        [SerializeField] private float RotationSpeed = 120;

        private Transform _movable;

        public void Init(Transform movable)
        {
            _movable = movable;
        }

        public void Move(float input, float deltaTime)
        {
            _movable.Translate(Vector3.forward * (input * deltaTime * Speed));
        }

        public void Rotate(float input, float deltaTime)
        {
            _movable.Rotate(Vector3.up, input * deltaTime * RotationSpeed);
        }
    }
}