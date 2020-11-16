using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class ScoreBoard : MonoBehaviour
{
    public int coins;
    public int highScore;
    public int totalCoins;
    public int totalDeaths;
    public int deaths;

    public TextMeshProUGUI TMscore;
    public TextMeshProUGUI TMcoins;
    public TextMeshProUGUI TMtotal;
    public TextMeshProUGUI TMdeath;
    // Use this for initialization
    void Start ()
    {
        

        highScore = PlayerPrefs.GetInt("highScore");
        totalCoins = PlayerPrefs.GetInt("totalCoins");
        totalDeaths = PlayerPrefs.GetInt("totalDeaths");

        coins = FindObjectOfType<CoinSingleton>().coins;
        deaths = FindObjectOfType<CoinSingleton>().deaths;

        totalDeaths = totalDeaths + deaths;
        SetDeaths(totalDeaths);

        totalCoins = totalCoins + coins;
        SetTotal(totalCoins);

        if(coins > highScore)
        {
            SetHighScore(coins);
            highScore = coins;
        }
        else
        {
            SetHighScore(highScore);
        }

    }

    private void Update()
    {
        TMscore.text = "High Score: " + highScore.ToString();
        TMcoins.text = "Coins Collected: " + coins.ToString();
        TMtotal.text = "Total Coins Collected: " + totalCoins.ToString();
        TMdeath.text = "Total Deaths: " + totalDeaths.ToString();
    }
    public void SetTotal(int value)
    {
        PlayerPrefs.SetInt("totalCoins", value);
    }

    public void SetHighScore(int value)
    {
        PlayerPrefs.SetInt("highScore", value);
    }

    public void SetDeaths(int value)
    {
        PlayerPrefs.SetInt("totalDeaths", value);
    }
}
