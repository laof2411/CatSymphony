using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // 0 = song - 1 
    [SerializeField] private AudioSource[] audioClips;

    [SerializeField] private HUDManager hudManager;
    [SerializeField] private NoteSpawnerManager spawnerManager;

    [SerializeField] private float currentSongSecond;

    private bool firstTimeStarting = true;

    private void Start()
    {

        StartSongTimer();

    }

    private void Update()
    {

        if (!GameManager.Instance.isPaused)
        {

            currentSongSecond += Time.deltaTime;
            audioClips[0].time = currentSongSecond;

        }

    }

    public void StartSongTimer()
    {

        StartCoroutine(StartTimer());

    }

    private IEnumerator StartTimer()
    {

        hudManager.UpdateStartingText("3");
        yield return new WaitForSecondsRealtime(1f);
        hudManager.UpdateStartingText("2");
        yield return new WaitForSecondsRealtime(1f);
        hudManager.UpdateStartingText("1");
        yield return new WaitForSecondsRealtime(1f);
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
