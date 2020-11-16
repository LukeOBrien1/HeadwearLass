using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int coinsCollected = 0;
    public Text coinText;
    public AudioSource music;
    public bool isComplete = false;

    // Use this for initialization
    void Start ()
    {
        
        coinsCollected = FindObjectOfType<CoinSingleton>().coins;
        music.Play();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        coinText.text = "Coins: " + coinsCollected;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void LevelComplete()
    {
        coinsCollected += 10;
        if (!isComplete)
        {
            StartCoroutine("LevelEnd");
        }

    }

    public IEnumerator LevelEnd()
    {
        isComplete = true;

        yield return new WaitForSeconds(2);

        isComplete = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    

}
