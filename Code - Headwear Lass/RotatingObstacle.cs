using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour {

    public float rotationZ;
    public float rotationX;
    private bool yeet = true;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Time.timeScale < 1f)
        {
            if(yeet)
            {
                rotationZ = rotationZ / 2;
                rotationX = rotationX / 2;
            }
            yeet = false;
        }
        else if (!yeet)
        {
            rotationZ = rotationZ * 2;
            rotationX = rotationX * 2;
            yeet = true;
        }

        transform.Rotate(rotationX * Time.deltaTime, 0, rotationZ * Time.deltaTime);
    }
}
