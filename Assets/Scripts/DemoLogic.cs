using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoLogic : MonoBehaviour
{

    private int deathCount = 0;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Player.playerDeath += onPlayerDeath;
        Enemy.enemyDeath += countEnemyDeath;
    }

    private void countEnemyDeath(int points)
    {
        deathCount++;
        Debug.Log(deathCount);
        if (deathCount >= 16)
        {
            deathCount = 0;
            EndGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Credits");
    }

    public void onPlayerDeath()
    {
        EndGame();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
