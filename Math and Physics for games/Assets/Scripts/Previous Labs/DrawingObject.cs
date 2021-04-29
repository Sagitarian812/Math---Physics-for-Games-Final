
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Drawing.Glint;

public class DrawingObject : MonoBehaviour
{
    public bool PerformDraw = true;
    public float Rotation = 0f;
    public float rotationDelta = 0f;
    public Vector3 Scale = Vector3.zero;
    public Vector3 Location;
    public List<Line> Lines = new List<Line>();
    public Color drawColor = Color.cyan;

    public virtual void Start()
    {
        Initalize();
    }

    public virtual void Initalize()
    {

    }

    public virtual void Update()
    {
        if (rotationDelta != 0)
        {
            Rotation += rotationDelta * Time.deltaTime;
        }

        if (PerformDraw)
        {
            Draw();
        }
    }

    /// <summary>
    /// Draws the Drawing Object Instance
    /// </summary>
    /// <param name="grid">Optional, When a Grid2d is applied, object is drawn relative to the grid and location is in Grid space</param>
    public virtual void Draw(Grid2D grid = null)
    {
        if (Lines.Count != 0)
        {
            for (int i = 0; i < Lines.Count; i++)
            {
                //Lines[i].Draw(grid);

                new Line(DrawingTools.RotatePoint(Location, Rotation, Lines[i].start + Location), DrawingTools.RotatePoint(Location, Rotation, Lines[i].end + Location), drawColor).Draw(grid);

            }
        }
    }

    public virtual bool PointInside(Vector3 point)
    {
        return false;
    }
}
