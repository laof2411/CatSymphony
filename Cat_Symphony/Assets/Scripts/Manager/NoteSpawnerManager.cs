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

        for (int i = 0; i < notesToSpawn.Length; i++)
        {

            float distance = Vector2.Distance(spawnPoints[notesToSpawn[i].trail_number].transform.position, objectives[notesToSpawn[i].trail_number].transform.position);
            float timeToReachObjective = distance / currentLevel.noteSpeed;
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

    public void InitializeSpawningCoroutines()
    {
        Debug.Log("Entrar");
        foreach(NoteInformation note in notesToSpawn)
        {

            StartCoroutine(SpawnNote(note.type, note.timeToSpawn, note.trail_number, note.hasPaw));

        }

    }

    private IEnumerator SpawnNote(NoteType type,float timer, int trailNumber, bool hasPaw)
    {

        Debug.Log("Hola");
        yield return new WaitForSeconds( timer );

        switch( type ) 
        {

            case NoteType.SingleTap:
                {

                    GameObject temp = Instantiate(singleTapNote, spawnPoints[trailNumber].transform.position, Quaternion.identity);
                    temp.transform.LookAt(objectives[trailNumber].transform);
                    temp.GetComponent<NoteBasicMovement>().transformObjective = objectives[trailNumber].transform;
                    temp.GetComponent<NoteBasicMovement>().moveSpeed = currentLevel.noteSpeed;
                    temp.GetComponent<SingleTapNoteEvent>().transformObjective = objectives[trailNumber].transform;
                    temp.GetComponent<BaseNoteScript>().hasPaw = hasPaw;
                    break;
                }
            case NoteType.HoldTap:
                {

                    GameObject temp = Instantiate(holdTapNote, spawnPoints[trailNumber].transform.position, Quaternion.identity);
                    temp.transform.LookAt(objectives[trailNumber].transform);
                    temp.GetComponent<NoteBasicMovement>().transformObjective = objectives[trailNumber].transform;
                    temp.GetComponent<NoteBasicMovement>().moveSpeed = currentLevel.noteSpeed;

                    temp.GetComponent<HoldTapNoteEvent>().transformObjective = objectives[trailNumber].transform;
                    temp.GetComponent<BaseNoteScript>().hasPaw = hasPaw;

                    //temp.GetComponent<HoldTapNoteEvent>().otherNote.transformObjective = objectives[trailNumber].transform;

                    // Esto no va a funcionar bien, pues en este metodo de SpawnNote solo tiene un bool de hasPaw, mientras que otherNote bien podria tener o no tener una paw, debera arreglarse despues
                    //temp.GetComponent<HoldTapNoteEvent>().otherNote.hasPaw = hasPaw;
                    break;
                }
            case NoteType.FreeStyle:
                {

                    GameObject temp = Instantiate(freeStyleNote, spawnPoints[trailNumber].transform.position, Quaternion.identity);
                    temp.transform.LookAt(objectives[5].transform);
                    temp.GetComponent<NoteBasicMovement>().transformObjective = objectives[5].transform;
                    temp.GetComponent<NoteBasicMovement>().moveSpeed = currentLevel.noteSpeed;

                    break;
                }

        }



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

}


public enum NoteType
{

    SingleTap,HoldTap,FreeStyle

}
