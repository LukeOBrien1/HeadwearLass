using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{

    public AudioSource slowDownActivateNoise;
    public AudioSource slowDownEndNoise;

    private bool activated = false;
    private bool hasCollided = false;
    public GameObject particles;
    public Transform playerParticles;
    // Start is called before the first frame update
    void Start()
    {
        slowDownActivateNoise = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (hasCollided)
        {
            if (!activated)
            {
                StartCoroutine("SlowDownActive");
            }
        }

        if(Time.timeScale < 1.0f)
        {
            Debug.Log("AAAAAAAAAAAGGGGG");
            //Instantiate(particles, playerParticles.position, playerParticles.rotation);
            particles.transform.position = playerParticles.position;
        }
        else
        {
            Debug.Log("EEEEEELLLLLSSSSSEEEE");
            //Destroy(particles);
            particles.transform.position = new Vector3(0, -300, 0);
            //particles.transform.position = new Vector3(1000, -1000, 0);
            //particles.transform.position = new Vector3(0, 1000, 0);
        }
    }

    public IEnumerator SlowDownActive()
    {
        
        
        activated = true;
        
        
        Time.timeScale = 0.4f;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(2);

        GetComponent<Collider>().enabled = true;
        slowDownEndNoise.Play();
        Time.timeScale = 1.0f;
        
        hasCollided = false;
        activated = false;
  

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            slowDownActivateNoise.Play();
            
            hasCollided = true;
            
        }
    }
}
