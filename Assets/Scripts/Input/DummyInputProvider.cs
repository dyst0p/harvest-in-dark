using UnityEngine;

namespace Input
{
    class DummyInputProvider : MonoBehaviour, IInputProvider
    {
        public float Move { get; private set; }
        public float Rotate { get; private set; }

        private void Update()
        {
            Move = 0;
            Rotate = 0;
            if (UnityEngine.Input.GetKey(KeyCode.W))
                Move += 1;
            if (UnityEngine.Input.GetKey(KeyCode.S))
                Move -= 1;
            if (UnityEngine.Input.GetKey(KeyCode.A))
                Rotate -= 1;
            if (UnityEngine.Input.GetKey(KeyCode.D))
                Rotate += 1;
        }
    }
}