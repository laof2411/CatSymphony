using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Level", menuName = "ArianMA ScriptableObjects", order = 0)]
public class LevelScriptableObject : ScriptableObject
{
    public string levelName;
    public string song;

    public int levelID;

    public int dificulty;
    public int sceneNumber;

    public int firstStarScore;
    public int secondStarScore;
    public int thirdStarScore;

    public float noteSpeed;
}
