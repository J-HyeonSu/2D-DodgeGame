using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# GameSettings")]
    public bool isLive;
    public int level = 1;
    public int score;
    public float[] spawnRateList = { .5f, .4f, .2f, .1f };
    public float spawnRate = 1f;
    public int levelUpTime = 10;
    

    [Header("# GameObjects")]
    public RainManager rainManager;
    public GameObject uiGameOver;
    public PlayerController playerController;
    public AchiveManager achiveManager;
    private float gameTime;
    private int pLevel = 1;
    
    private void Awake()
    {
        instance = this;
    }
    

    void Update()
    {
        if (!isLive) return;
        gameTime += Time.deltaTime;
        score += Mathf.FloorToInt(gameTime * pLevel);

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     level++;
        // }
        level = Mathf.FloorToInt(gameTime / levelUpTime) + 1;
        
        if (level > pLevel)
        {
            spawnRate = spawnRateList[Mathf.Clamp(level-1, 0, spawnRateList.Length-1)];
            pLevel = level;
        }

    }

    public void GameStart()
    {
        Debug.Log("game start");
        StartCoroutine(GameStartRoutine());

    }

    IEnumerator GameStartRoutine()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Resume();
    }

    public void GameOver()
    {
        
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        playerController.Dead();
        achiveManager.MaxScoreUpdate();
        isLive = false;
        
        yield return new WaitForSeconds(0.5f);
        uiGameOver.SetActive(true);
        Stop();
    }

    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
