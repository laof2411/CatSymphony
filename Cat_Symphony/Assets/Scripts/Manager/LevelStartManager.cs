using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartManager : MonoBehaviour
{

    [SerializeField] private AudioManager audioManager;
    [SerializeField] private NoteSpawnerManager noteSpawner;

    private void Start()
    {

        GameManager.Instance.PauseGame();
        audioManager.GetCurrentSong();
        audioManager.StartSongTimer();
        noteSpawner.GetCurrentNoteData();

    }

}
