using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMover : MonoBehaviour
{
    public float Speed = 1;
    public float RotationSpeed = 45;

    private void FixedUpdate()
    {
        float horInput = 0;
        float rotInput = 0;
        if (Input.GetKey(KeyCode.W))
            horInput += 1;
        if (Input.GetKey(KeyCode.S))
            horInput -= 1;
        if (Input.GetKey(KeyCode.A))
            rotInput -= 1;
        if (Input.GetKey(KeyCode.D))
            rotInput += 1;

        Rotate(rotInput);
        Move(horInput);
    }

    void Rotate(float input)
    {
        transform.Rotate(Vector3.up, input * Time.fixedDeltaTime * RotationSpeed);
    }
    
    void Move(float input)
    {
        transform.Translate(Vector3.forward * (input * Time.fixedDeltaTime * Speed));
    }
}
