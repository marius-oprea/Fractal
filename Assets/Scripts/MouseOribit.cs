using UnityEngine;
using System.Collections;

public class MouseOribit: MonoBehaviour 
{	
	public float speed = 10.0f;	
	private Bounds bound;

    public float friction; 
    public float lerpSpeed;
    
    private float xDeg;
    private float yDeg;

    private Quaternion fromRotation;
    private Quaternion toRotation;

    public float zoom;
    private Vector3 scale;

    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;

    
    private void Update () 
    { 
        if(Input.GetMouseButton(0)) 
        {
            xDeg -= Input.GetAxis("Mouse X") * speed;// *friction; 
            yDeg += Input.GetAxis("Mouse Y") * speed;// *friction; 
            
            Debug.Log("axa X: " + xDeg);
            
            //fromRotation = transform.rotation; 
            toRotation = Quaternion.Euler(yDeg,xDeg,0);

            //transform.rotation = toRotation;
            //transform.rotation = Quaternion.LookRotation( new Vector3(yDeg, xDeg, 0), Vector3.up);
            transform.eulerAngles = new Vector3(yDeg, xDeg, 0);
        }
        else
        {
            xDeg =  transform.rotation.x;
            yDeg =  transform.rotation.y;
        }
  
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
    
    /*
    private void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                float x = -Input.GetAxis("Mouse X");
                float y = -Input.GetAxis("Mouse Y");
                float speed = 10;
                transform.rotation *= Quaternion.AngleAxis(x * speed, Vector3.up);
                transform.rotation *= Quaternion.AngleAxis(y * speed, Vector3.right);
            }
        }
    }
    */
    private void Scale()
    {
        scale = new Vector3(zoom, zoom, zoom);
        transform.localScale = scale;
    }
}


