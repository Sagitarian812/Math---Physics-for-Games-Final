using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellipse : DrawingObject
{
   
    Vector3 _Axis = Vector3.one;
    public Vector3 Axis
    {
        get { return _Axis; }
        set
        {
            _Axis = value;
            Initalize();
        }

    }

    public int sides = 36;

    // Start is called before the first frame update
    public override void Initalize()
    {
        if (sides < 3) sides = 3;
        Lines.Clear();

        for (int i = 0; i < sides; i++)
        {
            Lines.Add(new Line(
                DrawingTools.EllipseRadiusPoint(Vector3.zero, (float)i / sides * 360f, _Axis),
                DrawingTools.EllipseRadiusPoint(Vector3.zero, (float)(i + 1) / sides * 360f, _Axis),
                Color.cyan));
        }
    }
}
