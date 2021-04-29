using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingTools
{ 

   public static float V3ToAngle(Vector3 startPoint, Vector3 endPoint)
    {
        return Mathf.Atan2(endPoint.y - startPoint.y, endPoint.x - startPoint.x);
    }

    public static float LineToAngle(Line line)
    {
        return V3ToAngle(line.start, line.end);
    }

    public static float toDegrees(float radian)
    {
        return (180 / Mathf.PI) * radian;
    }

    public static float toRadians(float degree)
    {
        return (Mathf.PI / 180) * degree;
    }

    public static Vector3 RotatePoint(Vector3 pivot, float angle, Vector3 point)
    {
        float cosAngle = Mathf.Cos(angle);
        float sinAngle = Mathf.Sin(angle);
        return new Vector3(
            (point.x - pivot.x) * cosAngle - (point.y - pivot.y) * sinAngle + pivot.x,
            (point.x - pivot.x) * sinAngle + (point.y - pivot.y) * cosAngle + pivot.y);
    }

    public static Vector3 CircleRadiusPoint(Vector3 origin, float angle, float radius)
    {
        return new Vector3(
            origin.x + Mathf.Cos(Mathf.Deg2Rad * angle) * radius,
            origin.y + Mathf.Sin(Mathf.Deg2Rad * angle) * radius,
            origin.z);
    }


    public static Vector3 EllipseRadiusPoint(Vector3 Origin, float angle, Vector3 Axis)
    {
        return new Vector3(
           Origin.x + Mathf.Cos(Mathf.Deg2Rad * angle) * Axis.x,
           Origin.y + Mathf.Sin(Mathf.Deg2Rad * angle) * Axis.y,
           Origin.z);
    }


    public static List<Vector3> shapePoints(int numberOfSides, float radius)
    {
        List<Vector3> points = new List<Vector3>();
        float angle = 360f / numberOfSides;

        points.Add(new Vector3(0, 1, 0));

        for (int i = 0; i <= numberOfSides; i++)
        {
            points.Add(DrawingTools.RotatePoint(Vector3.zero, angle, points[i]));
        }
        return points;
    }
}
