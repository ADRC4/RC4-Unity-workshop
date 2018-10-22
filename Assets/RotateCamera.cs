using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        MoveMouse();
    }

    void MoveMouse()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * 2;
            transform.RotateAround(Vector3.zero, Vector3.up, mouseX);
        }
    }
}