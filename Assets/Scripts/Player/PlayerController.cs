using Input;
using Player.Camera;
using Player.Movement;
using UnityEngine;

namespace Player
{
    public class PlayerController: MonoBehaviour, IMovable
    {
        public static PlayerController Instance;
        [SerializeField] private Transform _model;
        
        private IInputProvider _inputProvider;
        private IMover _mover;
        private ICameraController _cameraController;

        public Transform Self => transform;
        public Transform Model => _model;

        private void Awake()
        {
            Instance = this;
            
            _inputProvider = GetComponent<IInputProvider>();
            _mover = GetComponent<IMover>();
            _cameraController = GetComponentInChildren<ICameraController>();
            
            _mover.Init(this);
        }

        private void LateUpdate()
        {
            float deltaTime = Time.deltaTime;
            _mover.Move(_inputProvider.Move, deltaTime);
            _mover.Rotate(_inputProvider.Rotate, deltaTime);
            _cameraController.Zoom(_mover.RelativeSpeed);
        }
    }
}