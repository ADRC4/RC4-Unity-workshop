using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinCube : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody == null)
            return;

        var joint = this.gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = collision.rigidbody;
    }
}
