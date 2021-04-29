using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola3 : DrawingObject
{

    public override void Initalize()
    {


        parabola3();


       
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

}
