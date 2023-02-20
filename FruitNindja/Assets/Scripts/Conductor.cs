using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public float songBpm;

    public float secPerBeat;

    public float songPosition;

    public float songPositionInBeats;

    public float dspSongTime;

    public AudioSource musicSource;
    
    public float deltaTime;

    public List<float> timingList;
    
    [SerializeField] private ObjectInstantiate fruitInstantiate; 
    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        secPerBeat = 60f / songBpm;

        dspSongTime = (float)AudioSettings.dspTime;
        
        musicSource.Play();
    }
    
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        songPositionInBeats = songPosition / secPerBeat;
        foreach (var timing in timingList)
        {
            if (Math.Abs(songPosition - deltaTime - timing) < 0.1f)
            {
                // fruitInstantiate.Inst();
                timingList.Remove(timing);
                break;
            }
        }
    }
}
