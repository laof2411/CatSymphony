using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Level", menuName = "ArianMA ScriptableObjects", order = 0)]
public class LevelScriptableObject : ScriptableObject
{

    public string songName;
    public LevelDifficulty dififculty;
    public AudioClip songAudio;

    public int sceneID;
    public int levelID;
    public int level;

    public NoteLevelData noteData;

    public int firstStarScore;
    public int secondStarScore;
    public int thirdStarScore;

    public float noteSpeed;

    public int maxPaws;

    public int nekoinsFirstStar;
    public int nekoinsSecondStar;
    public int nekoinsThirdStar;
    
}

public enum LevelDifficulty
{

    Student,Professional,DJ

}
