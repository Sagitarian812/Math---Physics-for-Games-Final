﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingTest : DrawingObject
{
    public override void Update()
    {
        // do things then Draw();
        base.Update();
    }

    public override void Draw(Grid2D grid = null)
    {
		Glint.AddCommand(new Line(new Vector3(0,			0,				0), Input.mousePosition, Color.black));
		Glint.AddCommand(new Line(new Vector3(Screen.width, 0,				0), Input.mousePosition, Color.red));
		Glint.AddCommand(new Line(new Vector3(0,			Screen.height,	0), Input.mousePosition, Color.green));
		Glint.AddCommand(new Line(new Vector3(Screen.width, Screen.height,	0), Input.mousePosition, Color.blue));
	}
}
