using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public GameObject Player;
    public Vector3 startingPosition;
    public float movementAmountX;
    public float movementAmountY;
    public float movementAmountZ;
    public float movementTotal;
    public bool reverseMovement = false;
    public bool backwards;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        if(reverseMovement == false)
        {
            transform.position = new Vector3(transform.position.x + movementAmountX * Time.deltaTime, transform.position.y + movementAmountY * Time.deltaTime, transform.position.z + movementAmountZ * Time.deltaTime);
        }
        else if (reverseMovement == true)
        {
            transform.position = new Vector3(transform.position.x - movementAmountX * Time.deltaTime, transform.position.y - movementAmountY * Time.deltaTime, transform.position.z - movementAmountZ * Time.deltaTime);           
        }

        if (!backwards)
        {
            if (transform.position.z > (startingPosition.z + movementTotal) || transform.position.y > (startingPosition.y + movementTotal) || transform.position.x > (startingPosition.x + movementTotal))
            {
                reverseMovement = true;
            }
            if (transform.position.z < (startingPosition.z) || transform.position.y < (startingPosition.y) || transform.position.x < (startingPosition.x))
            {
                reverseMovement = false;
            }
        }

        if (backwards)
        {
            if (transform.position.z < (startingPosition.z + movementTotal) || transform.position.y < (startingPosition.y + movementTotal) || transform.position.x < (startingPosition.x + movementTotal))
            {
                reverseMovement = true;
            }
            if (transform.position.z > (startingPosition.z) || transform.position.y > (startingPosition.y) || transform.position.x > (startingPosition.x))
            {
                reverseMovement = false;
            }
        }
    }

}
