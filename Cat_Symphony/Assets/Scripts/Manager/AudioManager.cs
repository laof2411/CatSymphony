using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // 0 = song - 1 
    [SerializeField] private AudioSource[] audioClips;

    [SerializeField] private HUDManager hudManager;
    [SerializeField] private NoteSpawnerManager spawnerManager;

    private bool firstTimeStarting = true;

    private void Start()
    {
        
        StartSongTimer();

    }

    public void StartSongTimer()
    {

        StartCoroutine(StartTimer());

    }

    private IEnumerator StartTimer()
    {

        hudManager.UpdateStartingText("3");
        yield return new WaitForSeconds(1f);
        hudManager.UpdateStartingText("2");
        yield return new WaitForSeconds(1f);
        hudManager.UpdateStartingText("1");
        yield return new WaitForSeconds(1f);
        hudManager.UpdateStartingText("Start");

        if (firstTimeStarting)
        {

            audioClips[0].Play();
            spawnerManager.InitializeSpawningCoroutines();
            firstTimeStarting = false;

        }
        else
        {

            audioClips[0].UnPause();

        }


    }

}
