using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : DrawingObject
{
  
    public float radius = 1;
    public int sides = 6;

    public override void Initalize()
    {
        if (sides < 3) sides = 3;

        for (int i = 0; i < sides; i++)
        {
            Lines.Add(new Line(
                DrawingTools.CircleRadiusPoint(Vector3.zero, (float)i / sides * 360f, radius),
                DrawingTools.CircleRadiusPoint(Vector3.zero, (float)(i + 1) / sides * 360f, radius),
                Color.cyan));
        }
    }
}
