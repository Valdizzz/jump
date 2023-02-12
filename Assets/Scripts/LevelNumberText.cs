using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberText : MonoBehaviour
{
    public Text TextCurrent;
    public Text TextNext;
    public Text BestScore;
    public Text CurrentScore;
    public Game Game;
    public Player Player;

    private void Start()
    {
        TextCurrent.text = (Game.LevelIndex+1).ToString();
        TextNext.text = (Game.LevelIndex+2).ToString();
        
    }
    private void Update()
    {
        BestScore.text = "BEST SCORE : " + (Player.pointsBest).ToString();
        CurrentScore.text = (Player.pointsCount).ToString();
    }
}