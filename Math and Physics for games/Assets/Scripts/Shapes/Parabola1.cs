using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola1 : DrawingObject
{

    public override void Initalize()
    { 
        parabola1();
    }

    public void parabola1()
    {
        //y = x^2
        for (int i = -15; i < 15; i++)
        {
            float y1 = Mathf.Pow(i, 2);
            float y2 = Mathf.Pow(i + 1, 2);

            Vector3 screenLocation1 = new Vector3(i, y1, 0);
            Vector3 screenLocation2 = new Vector3(i + 1, y2, 0);

            Lines.Add(new Line(screenLocation1, screenLocation2, Color.red));
        }
    }

  
}
