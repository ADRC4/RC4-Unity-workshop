using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public GameObject Cube;
    Vector3 _size;

    void Start()
    {
        Random.InitState(42);
        Physics.autoSimulation = false;
        // var collider = Cube.GetComponentInChildren<BoxCollider>();
        //_size = collider.bounds.size;
        _size = new Vector3(0.125f, 0.075f, 0.375f);
        StartCoroutine(CreateJengaTower());
    }

    IEnumerator CreateJengaTower()
    {
        int layerWidth = 3;

        for (int i = 0; i < 54; i++)
        {
            int layer = i / layerWidth;
            int index = i % layerWidth;
            float xPos = (index - 1) * _size.x;
            float yPos = layer * _size.y;

            Vector3 position = new Vector3(xPos, yPos, 0) * 1.01f;
            Quaternion rotation = Quaternion.identity;
            var block = Instantiate(Cube, position, rotation, transform);

            if (layer % 2 == 0)
                block.transform.RotateAround(Vector3.zero, Vector3.up, 90);

            yield return new WaitForSeconds(0.1f);
        }
    }

    void CreateWall()
    {
        int layerWidth = 10;

        for (int i = 0; i < 100; i++)
        {
            int layer = i / layerWidth;
            int index = i % layerWidth;
            float xPos = (index - layerWidth / 2) * _size.x;
            float yPos = layer * _size.y;

            if (layer % 2 == 0)
            {
                xPos += 0.5f * _size.x;
            }

            Vector3 position = new Vector3(xPos, yPos, 0) * 1.01f;

            Quaternion rotation = Quaternion.identity;
            Instantiate(Cube, position, rotation, transform);
        }
    }

    void CreateColumn()
    {
        float gap = 1.01f;

        for (int i = 0; i < 10; i++)
        {
            Vector3 position = Vector3.up * gap * i;
            //var nudge = Random.insideUnitCircle * 0.3f;
            //position.x += nudge.x;
            //position.z += nudge.y;

            Quaternion rotation = Quaternion.Euler(0, i * 8, 0);

            var goA = Instantiate(
                        Cube,
                        position,
                        rotation,
                        this.transform
                        );
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 100, 40), "Enable physics"))
        {
            Physics.autoSimulation = true;
        }
    }
}
