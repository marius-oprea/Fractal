using UnityEngine;
using System.Collections;

public class Fractal : MonoBehaviour 
{
    private Mesh mesh;
    public Mesh sphereMesh;
    public Mesh cubeMesh;
    public Material material;

    public int maxDepth;
    public float childScale;

    public float rotateSpeed;

    private int depth;

    private Vector3[] childDirections = 
    {
		Vector3.up,
        Vector3.down,
		Vector3.right,
		Vector3.left,
		Vector3.forward,
		Vector3.back
	};

    private Quaternion[] childOrientations = 
    {
		Quaternion.identity,
        Quaternion.identity,
		Quaternion.Euler(0f, 0f, -90f),
		Quaternion.Euler(0f, 0f, 90f),
		Quaternion.Euler(90f, 0f, 0f),
		Quaternion.Euler(-90f, 0f, 0f)
	};

	// Use this for initialization
    private void Start()
    {
        mesh = sphereMesh;
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        CreateFractal();
    }

    private void CreateFractal()
    {
        //gameObject.AddComponent<MeshFilter>().mesh = mesh;
        //gameObject.AddComponent<MeshRenderer>().material = material;
        if (depth < maxDepth)
        {
            StartCoroutine(CreateChildren());
        }
    }

	private void Initialize (Fractal parent, int childIndex) 
    {
        mesh = parent.mesh;
        sphereMesh = parent.sphereMesh;
        cubeMesh = parent.cubeMesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        childScale = parent.childScale;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        //transform.localPosition = direction * (0.5f + 0.5f * childScale);
        //transform.localRotation = orientation;
        transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
		transform.localRotation = childOrientations[childIndex];
	}

    private IEnumerator CreateChildren()
    {
        for (int i = 0; i < childDirections.Length; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            new GameObject("Fractal Child").AddComponent<Fractal>().
                Initialize(this, i);
        }
    }

    public void PrimitiveChanged(string primitive)
    {
        switch(primitive)
        {
            case "SPHERE":
            {
                mesh = sphereMesh;
            }
            break;

            case "CUBE":
            {
                mesh = cubeMesh;
            }
            break;
        }

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        Transform child;
        for (int i = 0; i < gameObject.transform.childCount - 1; i++ )
        {
            child = gameObject.transform.GetChild(i);
            child.transform.parent = null;
        }

        //gameObject.GetComponent<MeshRenderer>().material = mesh;

        CreateFractal();
    }
}
