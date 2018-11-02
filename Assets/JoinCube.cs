using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinCube : MonoBehaviour
{
    public static float totalDistance = 0;


    private void OnCollisionEnter(Collision collision)
    {
        var pa = this.transform.position;
        var pb = collision.transform.position;
        var delta = pa - pb;
        var distance = delta.magnitude;
        totalDistance += distance;


        if (collision.rigidbody == null)
            return;

        var joint = this.gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = collision.rigidbody;
    }
}
