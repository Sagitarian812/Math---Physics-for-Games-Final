using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    Grid2D Grid;

    public Diamond diamond;
    public Hexagon hexagon;
    public Ellipse ellipse;
    public Circle circle;
    public Circle mousePoint;
    public Parabola1 parabola1;
    public Parabola2 parabola2;
    public Parabola3 parabola3;
    public Parabola4 parabola4;
    public RectangleOBJ rectangle;
    public Triangle triangle;


    public Vector3 worldPosition = Vector3.zero;
    public Vector3 mousePos = Vector3.zero;

    private void Awake()
    {
        diamond = gameObject.AddComponent<Diamond>();
        hexagon = gameObject.AddComponent<Hexagon>();
        ellipse = gameObject.AddComponent<Ellipse>();
        ellipse.Axis = new Vector3(2, 4, 0);
        circle = gameObject.AddComponent<Circle>();
        mousePoint = gameObject.AddComponent<Circle>();
        mousePoint.radius = 2f;
        Cursor.visible = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        Grid = gameObject.GetComponent<Grid2D>();
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = Input.mousePosition;
        mousePos.z = 0;
        worldPosition = Grid.ScreenToGrid(mousePos);
        // Debug.Log(worldPosition.x + " " + worldPosition.y);
        mousePoint.Location = mousePos;
        mousePoint.Draw();

        if (Grid.DrawMode == 0)
        {
            Grid.DrawObject(diamond);
            Grid.DrawModeDesc.text = "Drawing Diamond";
        }
        else if (Grid.DrawMode == 1)
        {
            Grid.DrawObject(hexagon);
            Grid.DrawModeDesc.text = "Drawing Hexagon";
        }

        else if (Grid.DrawMode == 2)
        {
            Grid.DrawObject(parabola1);
            Grid.DrawModeDesc.text = "Drawing y = x^2 Parabola";
        }

        else if (Grid.DrawMode == 3)
        {
            Grid.DrawObject(parabola2);
            Grid.DrawModeDesc.text = "Drawing y = x^2 + 2x+ 1 Parabola";
        }

        else if (Grid.DrawMode == 4)
        {
            Grid.DrawObject(parabola3);
            Grid.DrawModeDesc.text = "Drawing y = -2x^2 + 10x + 12 Parabola";
        }

        else if (Grid.DrawMode == 5)
        {
            Grid.DrawObject(parabola4);
            Grid.DrawModeDesc.text = "Drawing x = -y^3 Parabola";
        }

        else if (Grid.DrawMode == 6)
        {
            Grid.DrawObject(ellipse);
            Grid.DrawModeDesc.text = "Drawing Ellipse";
        }

        else if (Grid.DrawMode == 7)
        {

            if (circle.PointInside(worldPosition))
            {
                circle.drawColor = Color.red;
            }
            else
            {
                circle.drawColor = Color.white;
            }
            Grid.DrawObject(circle);
            Grid.DrawModeDesc.text = "Drawing Circle";
        }


        else if (Grid.DrawMode == 8)
        {

            if (rectangle.PointInside(worldPosition))
            {
                rectangle.drawColor = Color.red;
            }
            else
            {
                rectangle.drawColor = Color.white;
            }

            Grid.DrawObject(rectangle);
            Grid.DrawModeDesc.text = "Drawing Rectangle";
        }


        else if (Grid.DrawMode == 9)
        {

            if (triangle.PointInside(worldPosition))
            {
                triangle.drawColor = Color.red;
            }
            else
            {
                triangle.drawColor = Color.white;
            }

            Grid.DrawObject(triangle);
            Grid.DrawModeDesc.text = "Drawing Triangle";

        }
    }

   
}
