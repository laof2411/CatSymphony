using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] gameSoundMusic;
    public Sound[] gameSoundEffects;


    [SerializeField] private float volumeMusic = 100;
    [SerializeField] private float volumeEffect = 100;
    [SerializeField] private bool bongoSoundsActive;

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

    }

    private void Start()
    {
        foreach (Sound s in gameSoundMusic)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.loop = s.loop;
            s.audioSource.volume = s.volume;
        }

        foreach (Sound s in gameSoundEffects)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.loop = s.loop;
            s.audioSource.volume = s.volume;
        }
    }

    public void UpdateVolumeMusic()
    {
        foreach (Sound s in gameSoundMusic)
        {
            s.audioSource.volume = (s.volume * volumeMusic) / 100;
        }
    }

    public void UpdateVolumeEffects()
    {
        foreach (Sound s in gameSoundEffects)
        {
            s.audioSource.volume = (s.volume * volumeEffect) / 100;
        }
    }

    public void UpdateBongoSoundsActive(bool active)
    {
        bongoSoundsActive = active;

        foreach (Sound s in gameSoundEffects)
        {
            if (s.name == "Bongos")
            {
                s.audioSource.Stop();
                return;
            }
        }
    }

    public void LaunchSoundMusic(string name)
    {
        foreach (Sound s in gameSoundMusic)
        {
            if (s.name == name)
            {
                s.audioSource.Play();
                return;
            }
        }

        Debug.LogError("No Existe esa cancion");
    }

    public void StopSoundMusic(string name)
    {
        foreach (Sound s in gameSoundMusic)
        {
            if (s.name == name)
            {
                s.audioSource.Stop();
                return;
            }
        }

        Debug.LogError("No Existe esa cancion");
    }

    public void LaunchSoundEffects(string name)
    {
        foreach (Sound s in gameSoundEffects)
        {
            if (s.name == name)
            {
                s.audioSource.Play();
                return;
            }
        }

        Debug.LogError("No Existe esa cancion");
    }

    public void StopSoundEffects(string name)
    {
        foreach (Sound s in gameSoundEffects)
        {
            if (s.name == name)
            {
                s.audioSource.Stop();
                return;
            }
        }

        Debug.LogError("No Existe esa cancion");
    }
}
