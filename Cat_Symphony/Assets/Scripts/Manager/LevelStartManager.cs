using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartManager : MonoBehaviour
{

    [SerializeField] private AudioManager audioManager;
    [SerializeField] private NoteSpawnerManager noteSpawner;
    [SerializeField] private SettingsManager settings;

    private void Start()
    {

        GameManager.Instance.PauseGame();
        audioManager.GetCurrentSong();
        audioManager.StartSongTimer();

        noteSpawner.GetCurrentNoteData();
        settings.GetSettingsValues();
        audioManager.UpdateAudioSettings();

    }

}
