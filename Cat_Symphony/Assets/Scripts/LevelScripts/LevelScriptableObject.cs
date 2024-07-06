using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Level", menuName = "ArianMA ScriptableObjects", order = 0)]
public class LevelScriptableObject : ScriptableObject
{
    public string name;
    public string song;

    public int dificulty;
    public int sceneNumber;

    public float noteSpeed;
}
