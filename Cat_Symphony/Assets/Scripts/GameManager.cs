using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject dripStore;
    public GameObject songSelectionManager;

    public int[] currentCatLooks = new int[4];

    public int[,] levelSavesStars = new int[3, 3];
    public int[,] levelSavesPoints = new int[3, 3];
    public int[,] levelSavesPaws = new int[3, 3];
    public int testInt;

    public int nekoins;
    //No use for this int being public?

    public bool menuScreenHasBeenEntered;

    public LevelScriptableObject levelData;
    public bool isPaused = true;

    public SettingsData settings;

    public bool[] itemCatBought = new bool[] { true, false, false, false, false };
    public bool[] itemClothesBought = new bool[] { true, false, false, false, false };
    public bool[] itemAccesoriesBought = new bool[] { true, false, false, false, false };
    public bool[] itemBongoBought = new bool[] { true, false, false, false, false };

    public GameObject screen;

    void Awake()
    {
        if (Instance == null)
        {
            itemCatBought[0] = true;
            itemCatBought[1] = false;
            itemCatBought[2] = false;
            itemCatBought[3] = false;
            itemCatBought[4] = false;

            itemClothesBought[0] = true;
            itemClothesBought[1] = false;
            itemClothesBought[2] = false;
            itemClothesBought[3] = false;
            itemClothesBought[4] = false;

            itemAccesoriesBought[0] = true;
            itemAccesoriesBought[1] = false;
            itemAccesoriesBought[2] = false;
            itemAccesoriesBought[3] = false;
            itemAccesoriesBought[4] = false;

            itemBongoBought[0] = true;
            itemBongoBought[1] = false;
            itemBongoBought[2] = false;
            itemBongoBought[3] = false;
            itemBongoBought[4] = false;

            StartCoroutine(WaitASecond());

            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }


        Debug.Log("AWAKE!!");

        if (GameObject.FindAnyObjectByType<DripStoreManager>() == null) return;
        dripStore = GameObject.FindAnyObjectByType<DripStoreManager>().gameObject;
        //songSelectionManager = GameObject.FindAnyObjectByType<SongSelectionManager>().gameObject;


    }

    void Start()
    {
        AttemptLoadSave();

        //ResetData();
    }



    public void PauseGame()
    {

        isPaused = true;
        GameObject.FindFirstObjectByType<AudioManager>().PauseSong();

    }

    public void UnPauseGame()
    {

        isPaused = false;
        GameObject.FindFirstObjectByType<AudioManager>().UnPauseSong();

    }

    public void UpdateLevelScoresAndStars(int newScore, int newStars, int newPaws)
    {
        Debug.Log("Gamemanger: updating scores...");
        int level = levelData.level -1;
        int dificulty = 0;

        LevelDifficulty levelDifficulty = levelData.dififculty;

        switch (levelDifficulty)
        {
            case LevelDifficulty.Student:
                {
                    dificulty = 0;
                    break;
                }
            case LevelDifficulty.Professional:
                {
                    dificulty = 1;
                    break;
                }
            case LevelDifficulty.DJ:
                {
                    dificulty = 2;
                    break;
                }
        }

        if (levelSavesStars[level, dificulty] < newStars)
        {
            levelSavesStars[level, dificulty] = newStars;
        }

        if (levelSavesPoints[level, dificulty] < newScore)
        {
            levelSavesPoints[level, dificulty] = newScore;
        }

        if (levelSavesPaws[level, dificulty] < newPaws)
        {
            levelSavesPaws[level, dificulty] = newPaws;
        }

        Debug.Log("Gamemanger: score updated; stars: " + levelSavesStars[level, dificulty] + "; scores: " + levelSavesPoints[level, dificulty] + "; paws: " + levelSavesPaws[level, dificulty]);

        SaveSytem.SavePlayer();

    }



    #region LoadScenes
    public void LoadLevel(int levelID)
    {
        if (dripStore != null)
        {

            currentCatLooks = dripStore.GetComponent<DripStoreManager>().RecompileInfo();

        }

        levelData = FindAnyObjectByType<LevelDataHandler>().ReturnAskedLevel(levelID);

        SceneManager.LoadScene(1);

        DebuggingCatsLooks();
        //FindAnyObjectByType(LookChanger()).UpdateCatLooks();


        StartCoroutine(WaitASecond());
    }

    private IEnumerator WaitASecond()
    {
        yield return new WaitForSeconds(0.1f);

        screen = GameObject.FindGameObjectWithTag("MoveScreen");
        GameObject.FindGameObjectWithTag("MoveScreen").SetActive(false);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);


        StartCoroutine(WaitASecond());


        //songSelectionManager = FindAnyObjectByType<SongSelectionManager>().gameObject;
        //dripStore = GameObject.FindAnyObjectByType<DripStoreManager>().gameObject;

        //if (songSelectionManager != null)
        //{

        //    songSelectionManager.GetComponent<SongSelectionManager>().UpdateStars();

        //}
    }

    public void CollectDripstore(GameObject drip)
    {
        dripStore = drip;
    }

    private void DebuggingCatsLooks()
    {
        Debug.Log("A. currentCatLooks: " + currentCatLooks[0] + ", " + currentCatLooks[1] + ", " + currentCatLooks[2] + ", " + currentCatLooks[3]);
    }

    #endregion

    private void ResetData()
    {
        levelSavesStars[0, 0] = 0;
        levelSavesPoints[0, 0] = 0; ;
        levelSavesPaws[0, 0] = 0; ;

        levelSavesStars[0, 1] = 0; ;
        levelSavesPoints[0, 1] = 0; ;
        levelSavesPaws[0, 1] = 0; ;

        levelSavesStars[0, 2] = 0;
        levelSavesPoints[0, 2] = 0;
        levelSavesPaws[0, 2] = 0;


        levelSavesStars[1, 0] = 0;
        levelSavesPoints[1, 0] = 0;
        levelSavesPaws[1, 0] = 0;

        levelSavesStars[1, 1] = 0;
        levelSavesPoints[1, 1] = 0;
        levelSavesPaws[1, 1] = 0;

        levelSavesStars[1, 2] = 0;
        levelSavesPoints[1, 2] = 0;
        levelSavesPaws[1, 2] = 0;


        levelSavesStars[2, 0] = 0;
        levelSavesPoints[2, 0] = 0;
        levelSavesPaws[2, 0] = 0;

        levelSavesStars[2, 1] = 0;
        levelSavesPoints[2, 1] = 0;
        levelSavesPaws[2, 1] = 0;

        levelSavesStars[2, 2] = 0;
        levelSavesPoints[2, 2] = 0;
        levelSavesPaws[2, 2] = 0;

        SaveSytem.SavePlayer();

        Debug.Log("Reset Data");

    }

    private void AttemptLoadSave()
    {
        if (SaveSytem.LoadPlayer() != null)
        {
            PlayerData data = SaveSytem.LoadPlayer();


            testInt = data.testInt;


            levelSavesStars[0, 0] = data.levelSavesStars[0, 0];
            levelSavesPoints[0, 0] = data.levelSavesPoints[0, 0];
            levelSavesPaws[0, 0] = data.levelSavesPaws[0, 0];

            levelSavesStars[0, 1] = data.levelSavesStars[0, 1];
            levelSavesPoints[0, 1] = data.levelSavesPoints[0, 1];
            levelSavesPaws[0, 1] = data.levelSavesPaws[0, 1];

            levelSavesStars[0, 2] = data.levelSavesStars[0, 2];
            levelSavesPoints[0, 2] = data.levelSavesPoints[0, 2];
            levelSavesPaws[0, 2] = data.levelSavesPaws[0, 2];


            levelSavesStars[1, 0] = data.levelSavesStars[1, 0];
            levelSavesPoints[1, 0] = data.levelSavesPoints[1, 0];
            levelSavesPaws[1, 0] = data.levelSavesPaws[1, 0];

            levelSavesStars[1, 1] = data.levelSavesStars[1, 1];
            levelSavesPoints[1, 1] = data.levelSavesPoints[1, 1];
            levelSavesPaws[1, 1] = data.levelSavesPaws[1, 1];

            levelSavesStars[1, 2] = data.levelSavesStars[1, 2];
            levelSavesPoints[1, 2] = data.levelSavesPoints[1, 2];
            levelSavesPaws[1, 2] = data.levelSavesPaws[1, 2];


            levelSavesStars[2, 0] = data.levelSavesStars[2, 0];
            levelSavesPoints[2, 0] = data.levelSavesPoints[2, 0];
            levelSavesPaws[2, 0] = data.levelSavesPaws[2, 0];

            levelSavesStars[2, 1] = data.levelSavesStars[2, 1];
            levelSavesPoints[2, 1] = data.levelSavesPoints[2, 1];
            levelSavesPaws[2, 1] = data.levelSavesPaws[2, 1];

            levelSavesStars[2, 2] = data.levelSavesStars[2, 2];
            levelSavesPoints[2, 2] = data.levelSavesPoints[2, 2];
            levelSavesPaws[2, 2] = data.levelSavesPaws[2, 2];
            //SceneManager.LoadScene(1);

            Debug.Log("Level 1: " + levelSavesPoints[0, 0] + "/" + levelSavesStars[0, 0] + "/" + levelSavesPaws[0, 0]  + "; " + levelSavesPoints[0, 1] + "/" + levelSavesStars[0, 1] + "/" + levelSavesPaws[0, 1] + "; " + levelSavesPoints[0, 2] + "/" + levelSavesStars[0, 2] + "/" + levelSavesPaws[0, 2] + "; ");
            Debug.Log("Level 2: " + levelSavesPoints[1, 0] + "/" + levelSavesStars[1, 0] + "/" + levelSavesPaws[1, 0] + "; " + levelSavesPoints[1, 1] + "/" + levelSavesStars[1, 1] + "/" + levelSavesPaws[1, 1] + "; " + levelSavesPoints[1, 2] + "/" + levelSavesStars[1, 2] + "/" + levelSavesPaws[1, 2] + "; ");
            Debug.Log("Level 3: " + levelSavesPoints[2, 0] + "/" + levelSavesStars[2, 0] + "/" + levelSavesPaws[2, 0] + "; " + levelSavesPoints[2, 1] + "/" + levelSavesStars[2, 1] + "/" + levelSavesPaws[2, 1] + "; " + levelSavesPoints[2, 2] + "/" + levelSavesStars[2, 2] + "/" + levelSavesPaws[2, 2] + "; ");
        }
        else
        {

            Debug.Log("Save File NO encontrado");
        }
    }
}
