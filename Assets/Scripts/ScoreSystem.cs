using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public float score = 0f;
    public float highScore;
    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnEnemyDied += GetOnEnemyDied;
        Player.OnPlayerDied += GetOnPlayerDied;
        highScore = PlayerPrefs.GetInt("highscore", 0);
        PlayerPrefs.Save();
        string scoreString = $"Score \n {score}";
        string hiScoreString = $"High Score \n {highScore}";
        scoreText.text = scoreString;
        highScoreText.text = hiScoreString;
    }
    void GetOnEnemyDied(float pointWorth)
    {
      score += pointWorth;
      if(score > highScore)
      {
        highScore = score;
        int intScore = (int) highScore;
        PlayerPrefs.SetInt ("highscore", intScore);
        PlayerPrefs.Save();
      }
      string scoreString = $"Score \n {score}";
      string hiScoreString = $"High Score \n {highScore}";
      scoreText.text = scoreString;
      highScoreText.text = hiScoreString;
    }
    void GetOnPlayerDied()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
