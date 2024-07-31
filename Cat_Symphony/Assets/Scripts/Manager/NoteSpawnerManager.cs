using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NoteSpawnerManager : MonoBehaviour
{

    [Header("Note Prefabs")]
    [SerializeField] private GameObject singleTapNote;
    [SerializeField] private GameObject holdTapNote;
    [SerializeField] private GameObject freeStyleNote;

    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] objectives;

    public NoteInformation[] notesToSpawn;
    
    [SerializeField] private AudioManager audioManager;

    public void GetCurrentNoteData()
    {

        notesToSpawn = GameManager.Instance.levelData.noteData.noteInformation;
        RestoreAllNotes();

    }

    private void RestoreAllNotes()
    {


        for (int i = 0; i < notesToSpawn.Length; i++)
        {

            notesToSpawn[i].hasSpawned = false;

        }

        GetNoteSpawnTime();

    }

    private void GetNoteSpawnTime()
    {

        for (int i = 0; i < notesToSpawn.Length; i++)
        {

            float distance = Vector2.Distance(spawnPoints[notesToSpawn[i].trail_number].transform.position, objectives[notesToSpawn[i].trail_number].transform.position);
            float timeToReachObjective = distance / GameManager.Instance.levelData.noteSpeed;
            float time = notesToSpawn[i].timeToReachPerfect - timeToReachObjective;

            if (time < 0)
            {

                notesToSpawn[i].timeToSpawn = 0;

            }
            else
            {

                notesToSpawn[i].timeToSpawn = time;

            }


        }



    }

    private void Update()
    {
        
        if(!GameManager.Instance.isPaused)
        {

            for(int i = 0; i < notesToSpawn.Length; i++)
            {

                if (notesToSpawn[i].timeToSpawn <= audioManager.currentSongSecond && !notesToSpawn[i].hasSpawned)
                {

                    switch (notesToSpawn[i].type)
                    {

                        case NoteType.SingleTap:
                            {

                                GameObject temp = Instantiate(singleTapNote, spawnPoints[notesToSpawn[i].trail_number].transform.position, Quaternion.identity);
                                temp.transform.LookAt(objectives[notesToSpawn[i].trail_number].transform);
                                temp.GetComponent<NoteBasicMovement>().transformObjective = objectives[notesToSpawn[i].trail_number].transform;
                                temp.GetComponent<SingleTapNoteEvent>().transformObjective = objectives[notesToSpawn[i].trail_number].transform;
                                temp.GetComponent<BaseNoteScript>().hasPaw = notesToSpawn[i].hasPaw;
                                notesToSpawn[i].hasSpawned = true;
                                break;
                            }
                        case NoteType.HoldTap:
                            {

                                GameObject temp = Instantiate(holdTapNote, spawnPoints[notesToSpawn[i].trail_number].transform.position, Quaternion.identity);
                                temp.transform.LookAt(objectives[notesToSpawn[i].trail_number].transform);
                                temp.GetComponent<NoteBasicMovement>().transformObjective = objectives[notesToSpawn[i].trail_number].transform;

                                temp.GetComponent<HoldTapNoteEvent>().transformObjective = objectives[notesToSpawn[i].trail_number].transform;
                                temp.GetComponent<BaseNoteScript>().hasPaw = notesToSpawn[i].hasPaw;


                                temp.GetComponent<HoldTapNoteEvent>().otherNote.transformObjective = objectives[notesToSpawn[i].trail_number].transform;
                                notesToSpawn[i].hasSpawned = true;

                                // Esto no va a funcionar bien, pues en este metodo de SpawnNote solo tiene un bool de hasPaw, mientras que otherNote bien podria tener o no tener una paw, debera arreglarse despues
                                //temp.GetComponent<HoldTapNoteEvent>().otherNote.hasPaw = hasPaw;
                                break;
                            }
                        case NoteType.FreeStyle:
                            {

                                GameObject temp = Instantiate(freeStyleNote, spawnPoints[notesToSpawn[i].trail_number].transform.position, Quaternion.identity);
                                temp.transform.LookAt(objectives[5].transform);
                                temp.GetComponent<NoteBasicMovement>().transformObjective = objectives[5].transform;
                                notesToSpawn[i].hasSpawned = true;

                                break;
                            }

                    }


                    
                }

            }

        }

    }

    public void InitializeSpawningCoroutines()
    {

        foreach (NoteInformation note in notesToSpawn)
        {

            StartCoroutine(SpawnNote(note.type, note.timeToSpawn, note.trail_number, note.hasPaw));

        }

    }

    private IEnumerator SpawnNote(NoteType type, float timer, int trailNumber, bool hasPaw)
    {



        switch (type)
        {

            case NoteType.SingleTap:
                {

                    GameObject temp = Instantiate(singleTapNote, spawnPoints[trailNumber].transform.position, Quaternion.identity);
                    temp.transform.LookAt(objectives[trailNumber].transform);
                    temp.GetComponent<NoteBasicMovement>().transformObjective = objectives[trailNumber].transform;
                    temp.GetComponent<SingleTapNoteEvent>().transformObjective = objectives[trailNumber].transform;
                    temp.GetComponent<BaseNoteScript>().hasPaw = hasPaw;
                    break;
                }
            case NoteType.HoldTap:
                {

                    GameObject temp = Instantiate(holdTapNote, spawnPoints[trailNumber].transform.position, Quaternion.identity);
                    temp.transform.LookAt(objectives[trailNumber].transform);
                    temp.GetComponent<NoteBasicMovement>().transformObjective = objectives[trailNumber].transform;

                    temp.GetComponent<HoldTapNoteEvent>().transformObjective = objectives[trailNumber].transform;
                    temp.GetComponent<BaseNoteScript>().hasPaw = hasPaw;


                    temp.GetComponent<HoldTapNoteEvent>().otherNote.transformObjective = objectives[trailNumber].transform;

                    // Esto no va a funcionar bien, pues en este metodo de SpawnNote solo tiene un bool de hasPaw, mientras que otherNote bien podria tener o no tener una paw, debera arreglarse despues
                    //temp.GetComponent<HoldTapNoteEvent>().otherNote.hasPaw = hasPaw;
                    break;
                }
            case NoteType.FreeStyle:
                {

                    GameObject temp = Instantiate(freeStyleNote, spawnPoints[trailNumber].transform.position, Quaternion.identity);
                    temp.transform.LookAt(objectives[5].transform);
                    temp.GetComponent<NoteBasicMovement>().transformObjective = objectives[5].transform;

                    break;
                }

        }


        yield return null;

    }

}


[Serializable]
public struct NoteInformation
{

    public NoteType type;
    public int trail_number;

    public float timeToReachPerfect;
    public float timeToSpawn;

    public bool hasPaw;
    public bool hasSpawned;

}


public enum NoteType
{

    SingleTap, HoldTap, FreeStyle

}
