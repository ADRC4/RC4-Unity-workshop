using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public GameObject Cube;

    void Start()
    {
        Random.InitState(42);
        CreateWall();
    }

    void CreateWall()
    {
        int layerWidth = 10;

        for (int i = 0; i < 100; i++)
        {
            int layer = i / layerWidth;
            int index = i % layerWidth;
            float xPos = index - layerWidth / 2;

            if (layer % 2 == 0)
            {
                xPos += 0.5f;
            }

            Vector3 position = new Vector3(xPos, layer, 0) * 1.01f;

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
}
