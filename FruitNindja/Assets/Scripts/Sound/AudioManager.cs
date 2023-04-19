using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public bool musicOn = true;
    public bool sfxOn = true;
    
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Theme");
        musicSource.pitch = 1;
    }

    private void Update()
    {
        musicSource.mute = !musicOn;
        sfxSource.mute = !sfxOn;
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s==null)
        {
            Debug.Log("Music Not Found!");
        }
        else
        {
            if (name == "Spanch")
            {
                musicSource.pitch = 0.8f;
            }
            else
            {
                musicSource.pitch = 1;
            }
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s==null)
        {
            Debug.Log("SFX Not Found!");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
