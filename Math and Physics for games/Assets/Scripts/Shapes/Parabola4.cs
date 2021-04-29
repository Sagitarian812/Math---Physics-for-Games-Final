using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola4 : DrawingObject
{

    public override void Initalize()
    {


        parabola4();


       
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
