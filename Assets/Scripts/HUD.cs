using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour 
{
    public Toggle cubeButton;
    public Toggle sphereButton;

    private Fractal fractal;

    private void Awake()
    {
        fractal = GameObject.Find("Fractal").GetComponent<Fractal>();
    }

	// Use this for initialization
	private void Start () 
    {
        cubeButton.onValueChanged.AddListener(CubeButtonClicked);
        sphereButton.onValueChanged.AddListener(SphereButtonClicked);
	}
	
	// Update is called once per frame
	private void Update () 
    {
	
	}

    public void SphereButtonClicked(bool isOn)
    {
        fractal.PrimitiveChanged("SPHERE");
    }

    public void CubeButtonClicked(bool isOn)
    {
        fractal.PrimitiveChanged("CUBE");
    }
}
