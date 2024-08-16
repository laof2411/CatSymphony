using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // 0 = song - 1 = SongTimer - 2 = GainStar - 3 = BongoSound - 4 = FailCombo
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

            if (currentSongSecond >= audioClips[0].clip.length)
            {

                levelEndManager.EndLevelPublicMethod();
                GameManager.Instance.PauseGame();

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
        audioClips[1].Play();
        yield return new WaitForSecondsRealtime(1f);
        hudManager.UpdateStartingText("2");
        audioClips[1].Play();
        yield return new WaitForSecondsRealtime(1f);
        hudManager.UpdateStartingText("1");
        audioClips[1].Play();
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

    public void PlayBongoSound()
    {

        if (GameManager.Instance.settings.bongoSoundsActive)
        {

            audioClips[3].time = 0;
            audioClips[3].Play();


        }

    }

    public void PlayStarSound()
    {

        audioClips[2].Play();

    }

    public void PlayFailComboSound()
    {

        audioClips[4].Play();

    }

    public void UpdateAudioSettings()
    {

        
        audioClips[0].volume = GameManager.Instance.settings.musicVolume /100;
        audioClips[1].volume = GameManager.Instance.settings.effectsVolume / 100;
        audioClips[2].volume = GameManager.Instance.settings.effectsVolume / 100;
        audioClips[3].volume = GameManager.Instance.settings.effectsVolume / 100;
        audioClips[4].volume = GameManager.Instance.settings.effectsVolume / 100;
        audioClips[5].volume = GameManager.Instance.settings.effectsVolume / 100;

    }

}
