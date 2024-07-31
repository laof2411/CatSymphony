using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataHandler : MonoBehaviour
{

    //This script will hold ALL level data.

    [SerializeField] private LevelScriptableObject[] levels;

    public LevelScriptableObject ReturnAskedLevel(int levelID)
    {

        return levels[levelID];

    }

}
