using UnityEngine;

public interface IMover
{
    public void Init(Transform movable, Transform model);
    public void Move(float input, float deltaTime);
    public void Rotate(float input, float deltaTime);
}