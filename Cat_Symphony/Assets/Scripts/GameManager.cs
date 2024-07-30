using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject dripStore;

    public int[] currentCatLooks = new int[4];

    public int[,] levelSavesStars = new int[3, 3];
    public int[,] levelSavesPoints = new int[3, 3];
    public int testInt;

    public LevelScriptableObject levelData;
    public bool isPaused = false;

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

    public void PauseGame()
    {

        Time.timeScale = 0;
        isPaused = true;

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

            Debug.Log("Level 1: " + levelSavesPoints[0, 0] + "/" + levelSavesStars[0, 0] + "; " + levelSavesPoints[0, 1] + "/" + levelSavesStars[0, 1] + "; " + levelSavesPoints[0, 2] + "/" + levelSavesStars[0, 2] + "; ");
            Debug.Log("Level 2: " + levelSavesPoints[1, 0] + "/" + levelSavesStars[1, 0] + "; " + levelSavesPoints[1, 1] + "/" + levelSavesStars[1, 1] + "; " + levelSavesPoints[1, 2] + "/" + levelSavesStars[2, 2] + "; ");
            Debug.Log("Level 3: " + levelSavesPoints[2, 0] + "/" + levelSavesStars[2, 0] + "; " + levelSavesPoints[2, 1] + "/" + levelSavesStars[2, 1] + "; " + levelSavesPoints[2, 2] + "/" + levelSavesStars[2, 2] + "; ");
        }
        else
        {

            Debug.Log("Save File NO encontrado");
        }
    }


    public void UpdateLevelScoresAndStars(int ID, int dificulty, int newStars, int newScore)
    {
        if (levelSavesStars[ID, dificulty] < newStars)
        {
            levelSavesStars[ID, dificulty] = newStars;
        }

        if (levelSavesPoints[ID, dificulty] < newScore)
        {
            levelSavesPoints[ID, dificulty] = newScore;
        }
    }


    #region LoadScenes
    public void LoadLevel1()
    {
        currentCatLooks = dripStore.GetComponent<DripStoreManager>().RecompileInfo();

        Debug.Log("Load Scene level 1...");
        DebuggingCatsLooks();
        SceneManager.LoadScene(1);

        Debug.Log("Scene level 1 loaded!!");
    }

    public void LoadLevel2()
    {
        currentCatLooks = dripStore.GetComponent<DripStoreManager>().RecompileInfo();

        Debug.Log("Load Scene level 2...");
        DebuggingCatsLooks();
        SceneManager.LoadScene(2);

        Debug.Log("Scene level 2 loaded!!");
    }

    public void LoadLevel3()
    {
        currentCatLooks = dripStore.GetComponent<DripStoreManager>().RecompileInfo();

        Debug.Log("Load Scene level 3...");
        DebuggingCatsLooks();
        SceneManager.LoadScene(3);

        Debug.Log("Scene level 3 loaded!!");
    }

    public void LoadMainMenu()
    {
        Debug.Log("Load Scene Main Menu...");
        SceneManager.LoadScene(0);

        Debug.Log("Scene Main Menu loaded!!");
    }

    private void DebuggingCatsLooks()
    {
        Debug.Log("currentCatLooks: " + currentCatLooks[0] + ", " + currentCatLooks[1] + ", " + currentCatLooks[2] + ", " + currentCatLooks[3]);
    }

    #endregion
}
