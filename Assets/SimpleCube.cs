using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SimpleCube : MonoBehaviour
{
    public int X, Y;
    public GameObject[,] Grid;

    private void OnMouseDown()
    {
        var renderer = this.GetComponent<MeshRenderer>();
        var material = renderer.material;
        material.color = Color.white * 0.8f;

        if (X > 0) SetNeighbourColor(Grid[X - 1, Y]);
        if (X < Grid.GetLength(0) - 1) SetNeighbourColor(Grid[X + 1, Y]);

        if (Y > 0) SetNeighbourColor(Grid[X, Y - 1]);
        if (Y < Grid.GetLength(1) - 1) SetNeighbourColor(Grid[X, Y + 1]);
    }

    void SetNeighbourColor(GameObject neighbour)
    {
        var renderer = neighbour.GetComponent<MeshRenderer>();
        var material = renderer.material;
        material.color = Color.white * 0.2f;

        //Task.Run(() =>
        //{
        //    Task.Delay(100);
        //}).ConfigureAwait(false);
    }

    private void Update()
    {
        //if (Time.frameCount % 10 == 0)
        //{
        //    asdfasdf
        //}
    }
}
