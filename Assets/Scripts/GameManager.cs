using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int highScore = 0;
    public Text scoreText;
    public Text highScoreText;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0); // Load the high score from PlayerPrefs
        UpdateScore();
        UpdateHighScore();
        Enemy.enemyDeath += OnEnemyDeath;
    }

    void OnDestroy()
    {
        Enemy.enemyDeath -= OnEnemyDeath;
    }

    void OnEnemyDeath(int points)
    {
        score += points;
        UpdateScore();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); // Save the new high score to PlayerPrefs
            UpdateHighScore();
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString("D4");
    }

    void UpdateHighScore()
    {
        highScoreText.text = "High Score: " + highScore.ToString("D4");
    }
}