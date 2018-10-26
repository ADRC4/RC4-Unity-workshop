using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Populate : MonoBehaviour
{
    public GameObject tinySphere;
    List<TinySphere> tinySpheres = new List<TinySphere>();

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                float radius = 0.5f;
                Vector3 position = hit.point + hit.normal * radius;
                var instance = Instantiate(tinySphere, position, Quaternion.identity);
                var script = instance.GetComponent<TinySphere>();
                tinySpheres.Add(script);
            }
        }

        var subList = tinySpheres.Where(s => s.Number == 1);


        ////var subList = new List<TinySphere>();

        //foreach(var sphere in tinySpheres)
        //{
        //    if (sphere.Number == 1)
        //    {
        //        sphere.transform.position += Vector3.up * 0.1f;
        //      //  subList.Add(sphere);
        //    }

 
        //}


    }
}
