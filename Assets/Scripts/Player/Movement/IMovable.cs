using UnityEngine;

namespace Player.Movement
{
    public interface IMovable
    {
        public Transform Self { get; }
        public Transform Model { get; }
    }
}