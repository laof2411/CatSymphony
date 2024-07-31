using System.Collections;
using System.Collections.Generic;
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


    [SerializeField] private int finalScore;
    [SerializeField] private int finalStars;
    [SerializeField] private int finalPaws;

    public void EndLevelPublicMethod()
    {

        Invoke(nameof(EndLevel), waitingTime);

    }

    private void EndLevel()
    {

        GameManager.Instance.PauseGame();
        GetFinalData();
        pauseScreen.SetActive(true);
        pauseMenuManager.UpdatePauseData();
        songCanvas.SetActive(false);
        blockContinueImage.SetActive(true);
        continueButton.interactable = false;
        
    }

    private void GetFinalData()
    {

        finalScore = GameObject.FindAnyObjectByType<ScoreManager>().ReturnCurrentScore();
        finalStars = GameObject.FindAnyObjectByType<ScoreManager>().ReturnCurrentStars();
        finalPaws = GameObject.FindAnyObjectByType<PawsManager>().ReturnCurrentPaws();

    }
}
