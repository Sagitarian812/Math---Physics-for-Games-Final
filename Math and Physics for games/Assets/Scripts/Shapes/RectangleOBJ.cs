using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleOBJ : DrawingObject
{
    public Rect rectangle;

    public override void Initalize()
    {
        rectangle = new Rect(2.5f, 2.5f, 3, 2);
        BuildLines();
    }

    public override bool PointInside(Vector3 point)
    {
        return rectangle.Contains(point);
    }

    public void BuildLines()
    {
        Lines.Clear();
        Lines.Add(new Line(new Vector3(rectangle.xMin, rectangle.yMin, 0), new Vector3(rectangle.xMax, rectangle.yMin, 0), drawColor));
        Lines.Add(new Line(new Vector3(rectangle.xMax, rectangle.yMin, 0), new Vector3(rectangle.xMax, rectangle.yMax, 0), drawColor));
        Lines.Add(new Line(new Vector3(rectangle.xMax, rectangle.yMax, 0), new Vector3(rectangle.xMin, rectangle.yMax, 0), drawColor));
        Lines.Add(new Line(new Vector3(rectangle.xMin, rectangle.yMax, 0), new Vector3(rectangle.xMin, rectangle.yMin, 0), drawColor));
    }
}
