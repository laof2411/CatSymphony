using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public Sound[] gameSounds;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
            
        foreach (Sound s in gameSounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.loop = s.loop;
            s.audioSource.volume = s.volume;
        }
    }

    public void LaunchMusic(string nombre)
    {
        foreach (Sound s in gameSounds)
        {
            if (s.name == nombre)
            {
                s.audioSource.Play();
                return;
            }
        }

        Debug.LogError("No Existe esa cancion");
    }

    public void StopMusic(string nombre)
    {
        foreach (Sound s in gameSounds)
        {
            if (s.name == nombre)
            {
                s.audioSource.Stop();
                return;
            }
        }

        Debug.LogError("No Existe esa cancion");
    }
}
