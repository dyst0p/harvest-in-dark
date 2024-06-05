using Input;
using UnityEngine;

namespace Player
{
    public class PlayerController: MonoBehaviour
    {
        private IInputProvider _inputProvider;
        private IMover _mover;

        private void Awake()
        {
            _inputProvider = GetComponent<IInputProvider>();
            _mover = GetComponent<IMover>();
            _mover.Init(transform);
        }

        private void LateUpdate()
        {
            float deltaTime = Time.deltaTime;
            _mover.Rotate(_inputProvider.Rotate, deltaTime);
            _mover.Move(_inputProvider.Move, deltaTime);
        }
    }
}