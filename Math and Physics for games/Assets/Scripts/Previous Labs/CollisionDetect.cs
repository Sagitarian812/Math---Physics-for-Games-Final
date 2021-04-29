using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect
{

    public static bool SameSide(Vector3 point1, Vector3 point2, Vector3 pointA, Vector3 pointB)
    {
        Vector3 cross1 = Vector3.Cross(pointB - pointA, point1 - pointA);
        Vector3 cross2 = Vector3.Cross(pointB - pointA, point2 - pointA);

        if(Vector3.Dot(cross1, cross2) >=0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool PointInTriangle(Vector3 pointp, Vector3 pointA, Vector3 pointB, Vector3 pointC)
    {
        Debug.Log("Point P: " + pointp);
        if(SameSide(pointp,pointA, pointB,pointC) && SameSide(pointp,pointB,pointA,pointC) && SameSide(pointp, pointC, pointA,pointB))
        {
            return true;
        }
        else { return false; }
    }
}
