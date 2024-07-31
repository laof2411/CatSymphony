using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // 0 = song - 1 
    [SerializeField] private AudioSource[] audioClips;

    [SerializeField] private HUDManager hudManager;
    [SerializeField] private NoteSpawnerManager spawnerManager;
    [SerializeField] private LevelEndManager levelEndManager;

    [SerializeField] public float currentSongSecond;

    private bool firstTimeStarting = true;

    private void Update()
    {

        if (!GameManager.Instance.isPaused)
        {

            currentSongSecond += Time.deltaTime;

            if(currentSongSecond >= audioClips[0].clip.length)
            {

                levelEndManager.EndLevelPublicMethod();

            }

        }

    }

    public void GetCurrentSong()
    {

        audioClips[0].clip = GameManager.Instance.levelData.songAudio;

    }

    public void PauseSong()
    {

        audioClips[0].Pause();

    }

    public void UnPauseSong()
    {

        audioClips[0].UnPause();

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

            GameManager.Instance.UnPauseGame();
            audioClips[0].Play();
            //spawnerManager.InitializeSpawningCoroutines();
            firstTimeStarting = false;

        }
        else
        {

            GameManager.Instance.UnPauseGame();

        }


    }

}
