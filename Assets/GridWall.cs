using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridWall : MonoBehaviour
{
    public GameObject Box;
    GameObject[,] _boxes;


    void Start()
    {
        int width = 10;
        int height = 15;

        _boxes = new GameObject[width, height];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                var position = new Vector3(j, i + 0.5f, 0);
                var scale = new Vector3(1, 1, Random.Range(0.8f, 1.2f));
                var box = Instantiate(Box, this.transform);
                box.transform.position = position;
                box.transform.localScale = scale;
                var rb = box.GetComponent<Rigidbody>();

                if (i == 0)
                    rb.isKinematic = true;

                var simpleCube = box.GetComponent<SimpleCube>();
                simpleCube.X = j;
                simpleCube.Y = i;
                simpleCube.Grid = _boxes;

                _boxes[j, i] = box;
            }
        }

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (j < width - 1)
                {
                    var box = _boxes[j, i];
                    var rightBox = _boxes[j + 1, i];
                    AddJoint(box, rightBox);
                }

                if (i < height - 1)
                {
                    var box = _boxes[j, i];
                    var upBox = _boxes[j, i + 1];
                    AddJoint(box, upBox);
                }
            }
        }

    }

    void AddJoint(GameObject a, GameObject b)
    {
        var joint = a.AddComponent<FixedJoint>();
        var rightRb = b.GetComponent<Rigidbody>();
        joint.connectedBody = rightRb;
        joint.enableCollision = false;
        joint.breakForce = 600;
        joint.breakTorque = 600;
    }
}