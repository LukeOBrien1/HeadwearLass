using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCoin : MonoBehaviour {

    public AudioSource pickup;
    public GameObject particles;
    // Use this for initialization
    void Start()
    {
        pickup = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(90 * Time.deltaTime, 0, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            pickup.Play();
            Instantiate(particles, transform.position, transform.rotation);
            FindObjectOfType<GameManager>().coinsCollected++;
            FindObjectOfType<GameManager>().coinText.text = "Coins: " + FindObjectOfType<GameManager>().coinsCollected;
            FindObjectOfType<PlayerController>().SetRespawn(gameObject.transform);
            GetComponent<Collider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
