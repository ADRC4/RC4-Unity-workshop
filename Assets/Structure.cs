using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public GUISkin skin;
    public GameObject Cube;
    Vector3 _size;
    List<GameObject> _blocks = new List<GameObject>();
    int _count = 54;
    string _text = "";

    void Start()
    {
        Random.InitState(42);
        // var collider = Cube.GetComponentInChildren<BoxCollider>();
        //_size = collider.bounds.size;
        _size = new Vector3(0.125f, 0.075f, 0.375f);
        StartCoroutine(CreateJengaTower());
    }

    IEnumerator CreateJengaTower()
    {
        int layerWidth = 3;

        for (int i = 0; i < _count; i++)
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

            _blocks.Add(block);
            yield return new WaitForSeconds(0.01f);
        }

        StartCoroutine(RemoveBlocks());
    }

    void MoveBlock(GameObject block)
    {
        int layerWidth = 3;
        int layer = _count / layerWidth;
        int index = _count % layerWidth;
        float xPos = (index - 1) * _size.x;
        float yPos = layer * _size.y;

        Vector3 position = new Vector3(xPos, yPos, 0) * 1.01f;
        Quaternion rotation = Quaternion.identity;
        block.transform.position = position;
        block.transform.rotation = rotation;

        if (layer % 2 == 0)
            block.transform.RotateAround(Vector3.zero, Vector3.up, 90);
        _count++;
    }

    IEnumerator RemoveBlocks()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(2f);
            int index = Random.Range(0, _blocks.Count);
            var block = _blocks[index];
            MoveBlock(block);
            //_blocks.RemoveAt(index);
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

             Instantiate(
                        Cube,
                        position,
                        rotation,
                        this.transform
                        );
        }
    }

    private void Update()
    {
        Vector3 sumVelocity = Vector3.zero;

        foreach(var block in _blocks)
        {
            var rb = block.GetComponentInChildren<Rigidbody>();
            sumVelocity += rb.velocity;
        }

        if(sumVelocity.magnitude > 20)
        {
            _text = "You lost";
            Time.timeScale = 0.05f;
        }
    }

    private void OnGUI()
    {
        GUI.skin = skin;

        if (GUI.Button(new Rect(20, 20, 100, 40), "Enable physics"))
        {
            Physics.autoSimulation = true;
        }

        GUI.Label(new Rect(100, 100, 200, 50), _text);
    }
}
