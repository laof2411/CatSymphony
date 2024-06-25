using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //TryNewSave();
    }

    void TryNewSave()
    {
        GameManager.Instance.testInt = 24;


        GameManager.Instance.levelSavesStars[0, 0] = 2;
        GameManager.Instance.levelSavesPoints[0, 0] = 2000;

        GameManager.Instance.levelSavesStars[0, 1] = 3;
        GameManager.Instance.levelSavesPoints[0, 1] = 3000;

        GameManager.Instance.levelSavesStars[0, 2] = 1;
        GameManager.Instance.levelSavesPoints[0, 2] = 1000;


        GameManager.Instance.levelSavesStars[1, 0] = 2;
        GameManager.Instance.levelSavesPoints[1, 0] = 2000;

        GameManager.Instance.levelSavesStars[1, 1] = 3;
        GameManager.Instance.levelSavesPoints[1, 1] = 3000;

        GameManager.Instance.levelSavesStars[1, 2] = 1;
        GameManager.Instance.levelSavesPoints[1, 2] = 1000;


        GameManager.Instance.levelSavesStars[2, 0] = 2;
        GameManager.Instance.levelSavesPoints[2, 0] = 2000;

        GameManager.Instance.levelSavesStars[2, 1] = 3;
        GameManager.Instance.levelSavesPoints[2, 1] = 3000;

        GameManager.Instance.levelSavesStars[2, 2] = 1;
        GameManager.Instance.levelSavesPoints[2, 2] = 1000;


        SaveSytem.SavePlayer();
    }
}
