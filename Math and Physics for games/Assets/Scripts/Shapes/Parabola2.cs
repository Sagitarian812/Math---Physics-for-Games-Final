using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola2 : DrawingObject
{

    public override void Initalize()
    {
        parabola2();
 
    }

    public void parabola2()
    {
        for (int i = -15; i < 15; i++)
        {
            float y1 = Mathf.Pow(i, 2) + ((2 * i) + 1);
            float y2 = Mathf.Pow(i + 1, 2) + (2*(i+1) +1);

            Vector3 screenLocation1 = new Vector3(i, y1, 0);
            Vector3 screenLocation2 = new Vector3(i + 1, y2, 0);

            Lines.Add(new Line(screenLocation1, screenLocation2, Color.white));
        }
    }

    //y= -2x^2 +10x +12
    public void parabola3()
    {
        for (int i = -15; i < 15; i++)
        {
            float y1 = (-2 * Mathf.Pow(i, 2)) + ((10 * i) + 12);
            float y2 = (-2 * Mathf.Pow(i + 1, 2)) + (10 * (i + 1) + 12);

            Vector3 screenLocation1 = new Vector3(i, y1, 0);
            Vector3 screenLocation2 = new Vector3(i + 1, y2, 0);

            Lines.Add(new Line(screenLocation1, screenLocation2, Color.blue));
        }
    }

    //x = -y^3
    public void parabola4()
    {
        for (int i = -15; i < 15; i++)
        {
            float x1 = -Mathf.Pow(i,3);
            float x2 = -Mathf.Pow(i +1,3);

            Vector3 screenLocation1 = new Vector3(x1, i, 0);
            Vector3 screenLocation2 = new Vector3(x2, i+1, 0);

            Lines.Add(new Line(screenLocation1, screenLocation2, Color.green));
        }
    }
}
