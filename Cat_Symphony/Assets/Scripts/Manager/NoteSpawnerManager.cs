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

    [SerializeField] private NoteInformation[] notesToSpawn;

    private void Update()
    {



    }

}


public struct NoteInformation
{

    public NoteType type;
    public int number_SpawnPoint;
    public int number_objective;

    public float timeToReachPerfect;

}

public enum NoteType
{

    SingleTap,HoldTap,FreeStyle

}
