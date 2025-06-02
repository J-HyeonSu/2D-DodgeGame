using System;
using UnityEngine;
using UnityEngine.UI;

public class AchiveManager :MonoBehaviour
{
    private int MaxScore;

    public Text maxScoreText;
    public Text scoreText;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore", 0);
        }
        else
        {
            MaxScore = PlayerPrefs.GetInt("MaxScore");
        }
        
    }

    public void MaxScoreUpdate()
    {
        
        if (MaxScore < GameManager.instance.score)
        {
            MaxScore = GameManager.instance.score;
            PlayerPrefs.SetInt("MaxScore", MaxScore);
        }
        maxScoreText.text = $"최고기록 : {MaxScore}";
        scoreText.text = $"현재점수 : {GameManager.instance.score}";
    }
}
