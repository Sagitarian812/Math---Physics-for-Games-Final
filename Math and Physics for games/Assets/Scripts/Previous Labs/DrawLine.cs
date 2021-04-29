using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    Line lineToDraw;
    public Grid2D grid;

    public float angle;
    void Start()
    {
        lineToDraw = new Line(new Vector3(1, 1, 0), new Vector3(4,4,0), Color.cyan);
    }

    // Update is called once per frame
    void Update()
    {
        grid.DrawLine(lineToDraw);
       // DrawingTools.RotatePoint(lineToDraw.start, angle, lineToDraw.end);
    }
}
