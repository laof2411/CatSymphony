using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int[,] levelSavesStars = new int[3, 3];
    public int[,] levelSavesPoints = new int[3, 3];
    public int testInt;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    void Start()
    {
        AttemptLoadSave();
    }

    private void AttemptLoadSave()
    {
        if (SaveSytem.LoadPlayer() != null)
        {
            PlayerData data = SaveSytem.LoadPlayer();


            testInt = data.testInt;


            levelSavesStars[0, 0] = data.levelSavesStars[0, 0];
            levelSavesPoints[0, 0] = data.levelSavesPoints[0, 0];

            levelSavesStars[0, 1] = data.levelSavesStars[0, 1];
            levelSavesPoints[0, 1] = data.levelSavesPoints[0, 1];

            levelSavesStars[0, 2] = data.levelSavesStars[0, 2];
            levelSavesPoints[0, 2] = data.levelSavesPoints[0, 2];


            levelSavesStars[1, 0] = data.levelSavesStars[1, 0];
            levelSavesPoints[1, 0] = data.levelSavesPoints[1, 0];

            levelSavesStars[1, 1] = data.levelSavesStars[1, 1];
            levelSavesPoints[1, 1] = data.levelSavesPoints[1, 1];

            levelSavesStars[1, 2] = data.levelSavesStars[1, 2];
            levelSavesPoints[1, 2] = data.levelSavesPoints[1, 2];


            levelSavesStars[2, 0] = data.levelSavesStars[2, 0];
            levelSavesPoints[2, 0] = data.levelSavesPoints[2, 0];

            levelSavesStars[2, 1] = data.levelSavesStars[2, 1];
            levelSavesPoints[2, 1] = data.levelSavesPoints[2, 1];

            levelSavesStars[2, 2] = data.levelSavesStars[2, 2];
            levelSavesPoints[2, 2] = data.levelSavesPoints[2, 2];

            //SceneManager.LoadScene(1);
        }
        else
        {

            Debug.Log("Save File NO encontrado");
        }
    }
}
