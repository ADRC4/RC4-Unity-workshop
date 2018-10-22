using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    void Start()
    {
        delta = new Vector3(0, 0.01f, 0);
        direction = 1;
    }

    Vector3 delta;
    int direction;

    void Update()
    {
        if (transform.position.y > 3)
        {
            direction = -1;
        }

        if (transform.position.y < 0)
        {
            direction = 1;
        }

        transform.position += delta * direction;
        transform.Rotate(0, direction * 1, 0);
    }
}
