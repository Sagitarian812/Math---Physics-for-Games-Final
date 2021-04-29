using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ListUtility;
public class Diamond : DrawingObject
{


    // Start is called before the first frame update
    public override void Initalize()
    {
        Lines.Add(
              new Line(new Vector3(-1, 0), new Vector3(0, 1), Color.cyan),
              new Line(new Vector3(0, 1), new Vector3(1, 0), Color.cyan),
              new Line(new Vector3(1, 0), new Vector3(0, -1), Color.cyan),
              new Line(new Vector3(0, -1), new Vector3(-1, 0), Color.cyan)
              );

    }


}
