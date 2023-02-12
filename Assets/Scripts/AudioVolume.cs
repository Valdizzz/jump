using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolume : MonoBehaviour
{
    [Min(0)]
    public float Volume;
    private AudioListener _audioListner;

    private void Awake()
    {
        _audioListner = GetComponent<AudioListener>();
    }

    void Update()
    {

        AudioListener.volume = Volume;

    }
}
