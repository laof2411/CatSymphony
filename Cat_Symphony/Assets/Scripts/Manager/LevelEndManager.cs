using UnityEngine;
using UnityEngine.UI;

public class LevelEndManager : MonoBehaviour
{

    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject songCanvas;
    [SerializeField] private PauseMenuManager pauseMenuManager;
    [SerializeField] private GameObject blockContinueImage;
    [SerializeField] private Button continueButton;

    [SerializeField] private float waitingTime = 3;


    [SerializeField] public int finalScore;
    [SerializeField] public int finalStars;
    [SerializeField] public int finalPaws;

    public void EndLevelPublicMethod()
    {

        Invoke(nameof(EndLevel), waitingTime);

    }

    private void EndLevel()
    {
        Debug.Log("Level end!!");

        GameManager.Instance.PauseGame();
        GetFinalData();
        pauseScreen.SetActive(true);
        pauseMenuManager.LevelEndPause();
        songCanvas.SetActive(false);
        blockContinueImage.SetActive(true);
        continueButton.interactable = false;

        GameManager.Instance.UpdateLevelScoresAndStars(finalScore, finalStars, finalPaws);
        AddNekoinsToGameManager();
    }

    private void GetFinalData()
    {
        finalScore = GameObject.FindAnyObjectByType<ScoreManager>().ReturnCurrentScore();
        finalStars = GameObject.FindAnyObjectByType<ScoreManager>().ReturnCurrentStars();
        finalPaws = GameObject.FindAnyObjectByType<PawsManager>().ReturnCurrentPaws();

    }

    private void AddNekoinsToGameManager()
    {

        switch (finalStars)
        {

            case 1:
                GameManager.Instance.nekoins += GameManager.Instance.levelData.nekoinsFirstStar;
                break;
            case 2:
                GameManager.Instance.nekoins += GameManager.Instance.levelData.nekoinsFirstStar;
                GameManager.Instance.nekoins += GameManager.Instance.levelData.nekoinsSecondStar;
                break;
            case 3:
                GameManager.Instance.nekoins += GameManager.Instance.levelData.nekoinsFirstStar;
                GameManager.Instance.nekoins += GameManager.Instance.levelData.nekoinsSecondStar;
                GameManager.Instance.nekoins += GameManager.Instance.levelData.nekoinsThirdStar;
                break;

        }

    }
}
