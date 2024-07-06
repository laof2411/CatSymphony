using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawnerManager : MonoBehaviour
{

    [Header("Note Prefabs")]
    [SerializeField] private GameObject singleTapNote;
    [SerializeField] private GameObject holdTapNote;
    [SerializeField] private GameObject freeStyleNote;

    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] objectives;

    [SerializeField] private LevelScriptableObject currentLevel;

    public NoteInformation[] notesToSpawn;

    private void Start()
    {
        
        GetNoteSpawnTime();




    }

    private void GetNoteSpawnTime()
    {

        for(int i = 0; i > notesToSpawn.Length; i++)
        {

            notesToSpawn[i].timeToSpawn = notesToSpawn[i].timeToReachPerfect / currentLevel.noteSpeed;

        }

        InitializeSpawningCoroutines();

    }

    private void InitializeSpawningCoroutines()
    {

        foreach(NoteInformation note in notesToSpawn)
        {

            StartCoroutine(SpawnNote(note.type, note.timeToSpawn, note.number_SpawnPoint, note.number_objective));

        }

    }

    private IEnumerator SpawnNote(NoteType type,float timer, int spawnPoint, int objective )
    {

        yield return new WaitForSeconds( timer );

        switch( type ) 
        {

            case NoteType.SingleTap:
                {

                    GameObject temp = Instantiate(singleTapNote, spawnPoints[spawnPoint].transform.position, Quaternion.identity);
                    temp.transform.LookAt(objectives[objective].transform);
                    break;
                }
            case NoteType.HoldTap:
                {

                    GameObject temp = Instantiate(holdTapNote, spawnPoints[spawnPoint].transform.position, Quaternion.identity);
                    temp.transform.LookAt(objectives[objective].transform);
                    break;
                }
            case NoteType.FreeStyle:
                {

                    GameObject temp = Instantiate(freeStyleNote, spawnPoints[spawnPoint].transform.position, Quaternion.identity);
                    temp.transform.LookAt(objectives[5].transform);
                    break;
                }

        }

    }

}


[Serializable]
public struct NoteInformation
{

    public NoteType type;
    public int number_SpawnPoint;
    public int number_objective;

    public float timeToReachPerfect;
    public float timeToSpawn;

}


public enum NoteType
{

    SingleTap,HoldTap,FreeStyle

}
