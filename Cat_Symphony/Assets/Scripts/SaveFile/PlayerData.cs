using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[System.Serializable]
public class PlayerData
{
    //three levels, three dificulty; with score and points each

    public int[,] levelSavesStars = new int[3, 3];
    public int[,] levelSavesPoints = new int[3, 3];
    public int[,] levelSavesPaws = new int[3, 3];
    public int testInt;
    public int[] currentLooks = new int[4];

    // table form:
    //
    // level, dificulty; starter       ; master        ; dj
    // level 1         ; score, points ; score, points ; score, points ;
    // level 2         ; score, points ; score, points ; score, points ;
    // level 3         ; score, points ; score, points ; score, points ;


    public PlayerData()
    {
        testInt = GameManager.Instance.testInt;


        levelSavesStars[0, 0] = GameManager.Instance.levelSavesStars[0,0];
        levelSavesPoints[0, 0] = GameManager.Instance.levelSavesPoints[0, 0];
        levelSavesPaws[0, 0] = GameManager.Instance.levelSavesPaws[0, 0];

        levelSavesStars[0, 1] = GameManager.Instance.levelSavesStars[0, 1];
        levelSavesPoints[0, 1] = GameManager.Instance.levelSavesPoints[0, 1];
        levelSavesPaws[0, 1] = GameManager.Instance.levelSavesPaws[0, 1];

        levelSavesStars[0, 2] = GameManager.Instance.levelSavesStars[0, 2];
        levelSavesPoints[0, 2] = GameManager.Instance.levelSavesPoints[0, 2];
        levelSavesPaws[0, 2] = GameManager.Instance.levelSavesPaws[0, 2];


        levelSavesStars[1, 0] = GameManager.Instance.levelSavesStars[1, 0];
        levelSavesPoints[1, 0] = GameManager.Instance.levelSavesPoints[1, 0];
        levelSavesPaws[1, 0] = GameManager.Instance.levelSavesPaws[1, 0];

        levelSavesStars[1, 1] = GameManager.Instance.levelSavesStars[1, 1];
        levelSavesPoints[1, 1] = GameManager.Instance.levelSavesPoints[1, 1];
        levelSavesPaws[1, 1] = GameManager.Instance.levelSavesPaws[1, 1];

        levelSavesStars[1, 2] = GameManager.Instance.levelSavesStars[1, 2];
        levelSavesPoints[1, 2] = GameManager.Instance.levelSavesPoints[1, 2];
        levelSavesPaws[1, 2] = GameManager.Instance.levelSavesPaws[1, 2];


        levelSavesStars[2, 0] = GameManager.Instance.levelSavesStars[2, 0];
        levelSavesPoints[2, 0] = GameManager.Instance.levelSavesPoints[2, 0];
        levelSavesPaws[2, 0] = GameManager.Instance.levelSavesPaws[2, 0];

        levelSavesStars[2, 1] = GameManager.Instance.levelSavesStars[2, 1];
        levelSavesPoints[2, 1] = GameManager.Instance.levelSavesPoints[2, 1];
        levelSavesPaws[2, 1] = GameManager.Instance.levelSavesPaws[2, 1];

        levelSavesStars[2, 2] = GameManager.Instance.levelSavesStars[2, 2];
        levelSavesPoints[2, 2] = GameManager.Instance.levelSavesPoints[2, 2];
        levelSavesPaws[2, 2] = GameManager.Instance.levelSavesPaws[2, 2];

        currentLooks = GameManager.Instance.currentCatLooks;
    }

    public void UpdateLevelData()
    {
        Debug.Log("a");
    }
}
