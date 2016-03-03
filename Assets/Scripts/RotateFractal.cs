using UnityEngine;
using System.Collections;

public class RotateFractal : MonoBehaviour 
{
    private Vector2 clickPos;
    private Vector2 offsetPos;
    public int divider;
    public float zoom;
    private Vector3 scale;
 
    private void Start()
    {
        divider = 80;
        clickPos = new Vector2(0,0);
        offsetPos = new Vector2(0,0);
    }
 
    private void Update () 
    { 
        offsetPos = new Vector2(0,0);
     
        if(Input.GetKeyDown(leftClick()))
        {
            clickPos = mouseXY();
        }
     
        if(Input.GetKey(leftClick()))
        {
            offsetPos = clickPos - mouseXY();
        }
     
        // Rotate the GameObject
        transform.Rotate(new Vector3(-(offsetPos.y/divider),offsetPos.x/divider,0.0f), Space.World);


        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            zoom += Input.GetAxis("Mouse ScrollWheel");
            Scale();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) // backward
        {
            zoom += Input.GetAxis("Mouse ScrollWheel");
            Scale();
        }
    }

    private void Scale()
    {
        scale = new Vector3(zoom, zoom, zoom);
        transform.localScale = scale;
    }
 
    // Return true when left mouse is clicked or hold
    private KeyCode leftClick()
    {
        return KeyCode.Mouse0;
    }
 
    //Immediate location of the mouse
    private Vector2 mouseXY()
    {
        return new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }
 
    //Immediate location of the mouse's X coordinate
    private float mouseX()
    {
        return Input.mousePosition.x;
    }
 
    //Immediate location of the mouse's Y coordinate
    private float mouseY()
    {
        return Input.mousePosition.y;
    }		
}
