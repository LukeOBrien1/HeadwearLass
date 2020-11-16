using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // public variables
    public Transform target; // the players position
    public Transform pivot; // the pivots position
    public Vector3 offset; // position reletive to player
    public bool useOffsetValues;
    public float rotateSpeed;
    public float maxViewAngle;
    public float minViewAngle;

    // Use this for initialization
    void Start ()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        pivot.transform.position = target.transform.position;
        //get the x position of the mouse 
        float horizontalRotation = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontalRotation, 0);

        //get the y position of the mouse
        float verticalRotation = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.Rotate(-verticalRotation, 0, 0);

        float desiredYAngle = pivot.eulerAngles.y;

        //limit up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, desiredYAngle, 0);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f - minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360f - minViewAngle, desiredYAngle, 0);
        }

        //move camera based on the players rotation + offset
        //float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        if(transform.position.y  < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - 0.5f, transform.position.z);
        }

        //makes the camera look at the player
        transform.LookAt(target);
	}
}
