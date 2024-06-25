using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWinObject : MonoBehaviour
{

    [SerializeField] private int level;
    [SerializeField] private int dificulty;

    [SerializeField] private int levelScore;
    [SerializeField] private int levelPoints;

    private void Start()
    {
        ShowAllInfo();
        //SimulateLevelWin();
    }

    public void SimulateLevelWin()
    {
        GameManager.Instance.levelSavesStars[level, dificulty] = levelScore;
        GameManager.Instance.levelSavesPoints[level, dificulty] = levelPoints;
    }

    public void ShowAllInfo()
    {
        Debug.Log(GameManager.Instance.testInt);


        Debug.Log(GameManager.Instance.levelSavesStars[0, 0]);
        Debug.Log(GameManager.Instance.levelSavesPoints[0, 0]);

        Debug.Log(GameManager.Instance.levelSavesStars[0, 1]);
        Debug.Log(GameManager.Instance.levelSavesPoints[0, 1]);

        Debug.Log(GameManager.Instance.levelSavesStars[0, 2]);
        Debug.Log(GameManager.Instance.levelSavesPoints[0, 2]);


        Debug.Log(GameManager.Instance.levelSavesStars[1, 0]);
        Debug.Log(GameManager.Instance.levelSavesPoints[1, 0]);

        Debug.Log(GameManager.Instance.levelSavesStars[1, 1]);
        Debug.Log(GameManager.Instance.levelSavesPoints[1, 1]);

        Debug.Log(GameManager.Instance.levelSavesStars[1, 2]);
        Debug.Log(GameManager.Instance.levelSavesPoints[1, 2]);


        Debug.Log(GameManager.Instance.levelSavesStars[2, 0]);
        Debug.Log(GameManager.Instance.levelSavesPoints[2, 0]);

        Debug.Log(GameManager.Instance.levelSavesStars[2, 1]);
        Debug.Log(GameManager.Instance.levelSavesPoints[2, 1]);

        Debug.Log(GameManager.Instance.levelSavesStars[2, 2]);
        Debug.Log(GameManager.Instance.levelSavesPoints[2, 2]);
    }
}
