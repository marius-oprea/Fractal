using UnityEngine;
using System.Collections;

public class QuaternionRotation : MonoBehaviour
{

    float rotationSpeed = 0.5f;// This Must be less than 1 and greater than 0
    //public GameObject targetObject;// = null;

    // Use this for initialization
    void Start()
    {
        // get target object tobe rotated at
        //targetObject = this.gameObject;// GameObject.FindGameObjectWithTag("TargetObject") as GameObject;
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (targetObject == null)
        {
            Debug.Log("[ERROR] => Traget object is null , Can't Rotate");
            return;
        }
         */ 
        // get position of target object
//        Vector3 targetPosition = targetObject.transform.position;
        Vector3 targetPosition = Input.mousePosition;

        // calculate rotation to be done
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);

        //NOTE :: If you don't want rotation along any axis you can set it to zero is as :-
        // Setting Rotation along z axis to zero
        targetRotation.z = 0;

        // Setting Rotation along x axis to zero
        targetRotation.x = 0;

        // Apply rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}