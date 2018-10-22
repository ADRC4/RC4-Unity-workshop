using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        var rb = this.GetComponent<Rigidbody>();
        var force = Vector3.up * 50;

        rb.AddForce(force, ForceMode.Impulse);
    }
}
