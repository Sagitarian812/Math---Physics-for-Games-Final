using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Grid2D : DrawingObject
{

    public Vector3 ScreenSize;
    public Vector3 Origin;
    public float GridSize = 25f;
    public int DivisionCount = 5;
    public float minGridSize = 2f;
    public int minDivisionCount = 2;
    public float OriginSize = .6f;

    public Color AxisColor = Color.white;
    public Color LineColor = Color.gray;
    public Color DivisionColor = Color.yellow;

    public float AxisWidth = 3;
    public float DivisionWidth = 2;
    public float LineWidth = 1;

    public bool isDrawingOrigin = true;
    public bool isDrawingAxis = true;
    public bool isDrawingDivisions = true;
    public int DrawMode = 0;

    public Hexagon hexagon;

    public GameObject controls;
    public TextMeshProUGUI DrawModeDesc;

    // Start is called before the first frame update
    void Start()
    {
        ScreenSize = new Vector3(Screen.width, Screen.height, 0);
        Origin = ScreenSize / 2;

        hexagon = gameObject.AddComponent<Hexagon>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Input.GetKey(KeyCode.Mouse2))
        {
            Debug.Log("Scroll Pressed");
            Origin = Input.mousePosition;
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (isDrawingOrigin == false)
            {
                Debug.Log("Draw Divisions Toggled");
                isDrawingOrigin = true;
            }
            else
            {
                Debug.Log("Origin Draw Toggled");
                isDrawingOrigin = false;
            }
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (isDrawingAxis == false)
            {
                Debug.Log("Draw Divisions Toggled");
                isDrawingAxis = true;
            }

            else
            {
                Debug.Log("Draw Axis Toggled");
                isDrawingAxis = false;
            }
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            if (isDrawingDivisions == false)
            {
                Debug.Log("Draw Divisions Toggled");
                isDrawingDivisions = true;
            }
            else
            {
                Debug.Log("Draw Divisions Toggled");
                isDrawingDivisions = false;
            }
        }

        if (!Input.GetKey(KeyCode.LeftControl) && Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            GridSize++;
            Debug.Log("Grid Size is: " + GridSize);
        }
        else if (!Input.GetKey(KeyCode.LeftControl) && Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            GridSize--;
            Debug.Log("Grid Size is: " + GridSize);
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            DivisionCount++;
            Debug.Log("Division Count is: " + DivisionCount);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            DivisionCount--;
            Debug.Log("Division Count is: " + DivisionCount);
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (DrawMode <= 9)
            {
                DrawMode++;
            }
            if(DrawMode == 10)
            { DrawMode = 0; }
            tabWait();
        }

        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            controls.SetActive(false);
            Debug.Log("Panel is off");
        }
        else if (controls.activeInHierarchy && Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.BackQuote))
        {
            controls.SetActive(true);
            Debug.Log("Panel should be on");
        }

        base.Update();
    }

    public override void Draw(Grid2D grid = null)
    {
        bool keepDrawing = true;
        int index = 0;
        Color drawColor = Color.white;

        while (keepDrawing)
        {
            if ((index % DivisionCount == 0) && isDrawingDivisions)
            {
                drawColor = DivisionColor;
            }
            else
            {
                drawColor = LineColor;
            }

            if (isDrawingAxis && (index == 0))
            {
                drawColor = AxisColor;
            }

            //X Axis            
            Glint.AddCommand(new Line(new Vector3(0, Origin.y + (GridSize * index), 0), new Vector3(ScreenSize.x, Origin.y + (GridSize * index), 0), drawColor));

            //Y Axis   
            Glint.AddCommand(new Line(new Vector3(Origin.x + (GridSize * index), 0, 0), new Vector3(Origin.x + (GridSize * index), ScreenSize.y, 0), drawColor));

            //X Axis            
            Glint.AddCommand(new Line(new Vector3(0, Origin.y + (GridSize * -index), 0), new Vector3(ScreenSize.x, Origin.y + (GridSize * -index), 0), drawColor));

            //Y Axis   
            Glint.AddCommand(new Line(new Vector3(Origin.x + (GridSize * -index), 0, 0), new Vector3(Origin.x + (GridSize * -index), ScreenSize.y, 0), drawColor));


            index++;

            if (
               ((Origin.x + (GridSize * index)) > ScreenSize.x) &&
               ((Origin.y + (GridSize * index)) > ScreenSize.y) &&
               ((Origin.x + (GridSize * -index)) < 0) &&
               ((Origin.y + (GridSize * -index)) < 0)
               )
            {
                keepDrawing = false;
            }

            if (isDrawingOrigin)
            {
                DrawOrigin();
            }

        }

    }
    public void DrawOrigin()
    {
       if(isDrawingOrigin)
        {
            //DrawObject();
        }
    }

    public Vector3 GridToScreen(Vector3 location)
    {
        return ((location * GridSize) + Origin);
    }

    public Vector3 ScreenToGrid(Vector3 location)
    {
        return ((location - Origin) / GridSize);
    }

    public void DrawLine(Line drawLine, bool DrawOnGrid = true)
    {
        if (DrawOnGrid)
        {
            Glint.AddCommand(new Line(GridToScreen(drawLine.start), GridToScreen(drawLine.end), drawLine.color));
        }
        else
        {
            Glint.AddCommand(drawLine);
        }

    }

    public void DrawObject(DrawingObject lineObj, bool DrawOnGrid = true)
    {
        lineObj.Draw(DrawOnGrid ? this : null);

      /*  foreach (Line drawLine in lineObj.Lines)
        {
            DrawLine(drawLine, DrawOnGrid);
        }
       // DrawingTools.RotatePoint(lineObj.Lines[0],)*/
    }

    public float ScaleGrid2Screen(float value)
    {
        return (value * GridSize);
    }

    public float ScaleScreen2Grid(float value)
    {
        return (value / GridSize);
    }

    public IEnumerable tabWait()
    {
        yield return new WaitForSeconds(1f);
    }
}
