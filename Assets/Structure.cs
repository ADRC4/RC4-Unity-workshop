using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public GameObject Cube;

    void Start()
    {
        float gap = 1.02f;

        for (int i = 0; i < 10; i++)
        {
            var goA = Instantiate(
                        Cube,
                        Vector3.up * gap * i,
                        Quaternion.identity,
                        this.transform
                        );
        }
    }

    void Update()
    {

    }
}
