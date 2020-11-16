using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSingleton : MonoBehaviour
{
    static CoinSingleton instance;

    public int coins = 0;
    public int deaths = 0;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddCoins()
    {
        coins = FindObjectOfType<GameManager>().coinsCollected;
    }

    public void ResetCoins()
    {
        coins = 0;
    }
}
