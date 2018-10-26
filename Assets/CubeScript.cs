using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    void Start()
    {
        var renderer = this.GetComponent<MeshRenderer>();
        var material = new Material(renderer.material);
        //var color = Random.ColorHSV(0.5f, 0.7f, 0.5f, 0.8f, 0.5f, 0.5f);
        var color = Color.white * Random.Range(0.2f, 0.6f);
        material.color = color;
        renderer.material = material;
    }

    void OnMouseDown()
    {
        var rb = this.GetComponent<Rigidbody>();
        var force = Vector3.up * 50;

        rb.AddForce(force, ForceMode.Impulse);
    }
}
