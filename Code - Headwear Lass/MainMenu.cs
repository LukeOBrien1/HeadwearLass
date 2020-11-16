using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public AudioSource menuMusic;
    

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        menuMusic.Play();
        
    }
    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if ( sceneName == "End")
            {
                PlayAgain();
            }
            else
            {
                PlayGame();
            }
            
        }
        if (Input.GetButtonDown("Fire2"))
        {
            QuitGame();
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void PlayAgain()
    {
        FindObjectOfType<CoinSingleton>().ResetCoins();
        SceneManager.LoadScene("LevelOne");
    }
}
