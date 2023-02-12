using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
    
{
    public AudioClip BackGroundMusic;
    public AudioClip PlayerDie;
    public AudioClip FinishMusic;

    private AudioSource _audio;
    [Min(0)]
    public float volume;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>(); 
    }
    public void DieSound()
    {
        _audio.PlayOneShot(PlayerDie);
    }
    public void PlayFinish()
    {
        _audio.PlayOneShot(FinishMusic);
    }
    public void OnEnable()
    {
        _audio.Play();
    }
}

