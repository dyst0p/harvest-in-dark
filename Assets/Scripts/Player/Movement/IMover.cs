namespace Player.Movement
{
    public interface IMover
    {
        public float RelativeSpeed { get; }
    
        public void Init(IMovable movable);
        public void Move(float input, float deltaTime);
        public void Rotate(float input, float deltaTime);
    }
}