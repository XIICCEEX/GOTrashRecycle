using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketControllerScript : MonoBehaviour
{
    
    public KeyCode moveForwardKey = KeyCode.W;
    public KeyCode moveBackKey = KeyCode.S;
    public KeyCode turnLeftKey = KeyCode.A;
    public KeyCode turnRightKey = KeyCode.D;

    
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;

    
    void MoveForward()
    {
        Vector3 moveVector = Vector3.forward;
        transform.Translate(moveVector * Time.deltaTime * moveSpeed);
    }

    void MoveBackward()
    {
        Vector3 moveVector = Vector3.back;
        transform.Translate(moveVector * Time.deltaTime * moveSpeed);
    }

    
    void RotateLeft()
    {
        Vector3 rotateVector = Vector3.up;
        transform.Rotate(rotateVector * Time.deltaTime * -turnSpeed);
    }

    void RotateRight()
    {
        Vector3 rotateVector = Vector3.up;
        transform.Rotate(rotateVector * Time.deltaTime * turnSpeed);
    }

  
    void DetectInput()
    {
        if (Input.GetKey(moveForwardKey)) { MoveForward(); }
        if (Input.GetKey(moveBackKey)) { MoveBackward(); }
        if (Input.GetKey(turnLeftKey)) { RotateLeft(); }
        if (Input.GetKey(turnRightKey)) { RotateRight(); }
    }

    void Update()
    {
        DetectInput();
    }
}
