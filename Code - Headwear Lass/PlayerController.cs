using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //public variables
    public float moveSpeed;
    public float jumpForce; 
    public float gravityScale;
    public AudioSource jump;
    public AudioSource death;


    public CharacterController controller;
    public Animator anim;
    public Transform pivot;
    public float cameraRotateSpeed;
    public GameObject playerModel;
    public Vector3 respawnPoint;
    public bool isRespawning = false;
    //private variables 
    private Vector3 moveDirection;

    

	// Use this for initialization
	void Start ()
    {
        // when the player is spawned, this line will get the players CharacterController component
        controller = GetComponent<CharacterController>();
        respawnPoint = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        

        // setting the players movement
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        //check if the player is on the ground
        if (controller.isGrounded)
        {
            moveDirection.y = -0.3f;
            //if 'spacebar' is pressed, then the player jumps
            if (Input.GetButtonDown("Jump"))
            {
                jump.Play();
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime); //applying gravity

        // using time.deltaTime so that the players movement is the same speed at any framerate
        controller.Move(moveDirection * Time.deltaTime);

        //basing the players movement on the cameras rotation
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);

            //stopping the player model from snapping to a rotation using Slerp
            Quaternion newPlayerRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newPlayerRotation, cameraRotateSpeed * Time.deltaTime);
        }

        //respawning
        if(transform.position.y < -20)
        {
            if(!isRespawning)
            {
                StartCoroutine("RespawnTime");
            }

        }


        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

    }

    public IEnumerator RespawnTime()
    {
        isRespawning = true;
        death.Play();

        Component[] a = GetComponentsInChildren(typeof(Renderer));
        foreach (Component b in a)
        {
            Renderer c = (Renderer)b;
            c.enabled = false;
        }

        yield return new WaitForSeconds(2);

        isRespawning = false;
        transform.position = respawnPoint;

        foreach (Component b in a)
        {
            Renderer c = (Renderer)b;
            c.enabled = true;
        }
        GetComponent<MeshRenderer>().enabled = false;
        FindObjectOfType<CoinSingleton>().deaths++;
    }

    public void SetRespawn(Transform newRespawn)
    {
        respawnPoint = newRespawn.transform.position;
    }

    private bool IsGrounded()
    {
        if (controller.isGrounded)
        {
            return true;
        }
           
        //get center of player - height/2 to get the bottom of the player
        Vector3 bottom = controller.transform.position - new Vector3(0, controller.height / 2, 0);

        RaycastHit hit; //create raycast

        // if the player is within .2 of the ground then it is considered grounded
        if (Physics.Raycast(bottom, new Vector3(0, -1, 0), out hit, 0.2f))
        {
            controller.Move(new Vector3(0, -hit.distance, 0));
            return true;
        }
        return false;
    }
}
