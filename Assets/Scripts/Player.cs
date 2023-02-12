using Assets.Scripts;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Game Game;
    private AudioSource _bounceSound;
    public int pointsCount;
    public AudioPlayer AudioPlayer;
    public int pointsBest;
    public Material _Player;
    

    public Platform CurrentPlatform;
   // private float DissolveSpeed = -1.0f;

    public int PointsBest { get => pointsBest; set => pointsBest = value; }

    public void Bounce() 
    {
        Rigidbody.velocity = new Vector3 (0,BounceSpeed,0);
        _bounceSound.Play();
        _Player.SetFloat("_Float", -1f);
    }

    public void ReachFinish()
    {
        AudioPlayer.PlayFinish();
        Rigidbody.velocity = Vector3.zero;
        Game.OnPlayerReachedFinish();
    }
    public void Dissolve()
    {
        for (float i = -1f; i <= 1f; i = i + 0.001f)
        {
            _Player.SetFloat("_Float", i);
            if (i > 1 | i < -1) 
            {
                _Player.SetFloat("_Float", -1f);
                return;
            }
        }
    }
    
    public void Die()
    {
        

        AudioPlayer.DieSound();
        Rigidbody.velocity = Vector3.zero;
        pointsCount=0;
        Dissolve();
        Game.OnPlayerDied();
        
        
        
    }
    public void Count()
    {
        pointsCount++;
        if (pointsCount >= pointsBest) pointsBest = pointsCount;
        Debug.Log("Count: "+pointsCount);
        Debug.Log("Best: "+pointsBest);
    }
    private void Start()
    {
        Game.BestScoreGet();
        Game.ScorePointsGet();
        _bounceSound = GetComponent<AudioSource>();
        
    }
    private void Update()
    {
        

        // Game.ScorePointsGet(); 
    }
}
