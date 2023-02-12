using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Control Control;
    public Player Player;
    public enum State
    {
        Playing,
        Won,
        Loss
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Control.enabled = false;
        Debug.Log("Game over!");
        PointsIndex = 0;
        StartCoroutine(ExampleCoroutine());
        
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState= State.Won;
        Control.enabled = false;
        LevelIndex++;
        BestScoreIndex = Player.pointsBest;
        PointsIndex = Player.pointsCount;
        Debug.Log("You won");
        StartCoroutine(ExampleCoroutine());
        
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIdexKey, 0);
        private set 
        { 
            PlayerPrefs.SetInt(LevelIdexKey, value);
            PlayerPrefs.Save();
        }
    }

    public int BestScoreIndex
    {
        get => PlayerPrefs.GetInt(BestScoreIndexKey, 0);
        set
        {
            PlayerPrefs.SetInt(BestScoreIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    public int PointsIndex
    {
        get => PlayerPrefs.GetInt(PointsIndexKey, 0);
        set
        {
            PlayerPrefs.SetInt(PointsIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    public void BestScoreGet()
    {
        Player.pointsBest = BestScoreIndex;
    }

    public void ScorePointsGet()
    {
        Player.pointsCount = PointsIndex;
    }

    private const string PointsIndexKey = "PointsIndexKey";
    private const string BestScoreIndexKey = "BestSoreIndex";
    private const string LevelIdexKey = "LevelIndex";
    private void Awake()
    {
        if (PointsIndex>-1)PointsIndex--;
    }
    private void ReloadLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
        
    IEnumerator ExampleCoroutine()
    {
        
        yield return new WaitForSeconds(2);
        ReloadLevel();
    }
}
