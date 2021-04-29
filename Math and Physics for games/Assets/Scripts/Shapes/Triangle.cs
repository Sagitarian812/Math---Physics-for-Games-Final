using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ListUtility;

public class Triangle : DrawingObject
{
    public Vector3 pointA;
    public Vector3 pointB;
    public Vector3 pointC;

    public override void Initalize()
    {
        pointA = new Vector3(0, 1, 0);
        pointB = new Vector3(1, 0, 0);
        pointC = new Vector3(-1, 0, 0);

        BuildLines();
    }
    public override bool PointInside(Vector3 point)
    {
        return CollisionDetect.PointInTriangle(point, pointA, pointB, pointC);
    }

    public void BuildLines()
    {
        Lines.Clear();
        Lines.Add(new Line(pointA, pointB, drawColor), new Line(pointB,pointC,drawColor), new Line(pointC,pointA,drawColor));
    }
}
