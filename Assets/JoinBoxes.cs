using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinBoxes : MonoBehaviour
{
    public GameObject Box;

    void Start()
    {
        StartCoroutine(DropBoxes());
    }

    void Update()
    {

    }

    IEnumerator DropBoxes()
    {
        while (true)
        {
            var box = Instantiate(Box, this.transform);
            box.transform.position = new Vector3(0, 10, 0);
            box.transform.rotation = Random.rotation;
            yield return new WaitForSeconds(1);
        }
    }
}
