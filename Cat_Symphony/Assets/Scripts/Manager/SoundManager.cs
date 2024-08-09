using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public Sound[] gameSounds;

    public float[] originalGameVolumes;

    void Awake()
    {
        if (Instance == null)
        {
            originalGameVolumes = new float[gameSounds.Length];
            int tracker = 0;

            foreach (Sound s in gameSounds)
            {
                s.audioSource = gameObject.AddComponent<AudioSource>();
                s.audioSource.clip = s.clip;
                s.audioSource.loop = s.loop;
                s.audioSource.volume = s.volume;

                originalGameVolumes[tracker] = s.audioSource.volume;

                tracker++;
            }

            for (int i = 0; i < gameSounds.Length; i++)
            {
                originalGameVolumes[i] = gameSounds[i].audioSource.volume;
            }

            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
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

        Debug.LogError("No Existe cancion: " + nombre);
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


    public Sound[] gameVolumes;

    public void ModifyMusic()
    {
        float newValue;
        for(int i = 0; i < originalGameVolumes.Length; i++)
        {
            //AudioSource audioSource[] = new AudioSource[gameObject.GetComponents<AudioSource>()];
            AudioSource[] audioSource = gameObject.GetComponents<AudioSource>();

            newValue = originalGameVolumes[i] * GameManager.Instance.settings.effectsVolume;
            gameSounds[i].volume = newValue / 100f;
            audioSource[i].volume = newValue / 100f;

            Debug.Log("Song: " + audioSource[i].name + "; new value: " + newValue);

            //gameSounds[i].volume = ;

            //newValue = s.volume * (GameManager.Instance.settings.effectsVolume/100);
            //s.volume = newValue;
            //Debug.Log(newValue);
        }

        //foreach (Sound s in gameSounds)
        //{
        //    AudioSource[] audioSource = gameObject.GetComponents<AudioSource>(); 
        //}

            //Debug.LogError("No Existe esa cancion");
    }
}
