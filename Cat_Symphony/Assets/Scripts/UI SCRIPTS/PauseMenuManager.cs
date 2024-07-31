using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI pawsText;
    [SerializeField] private GameObject[] fillStars;

    public void UpdatePauseData()
    {

        scoreText.text = "Score: " + GameObject.FindAnyObjectByType<ScoreManager>().ReturnCurrentScore().ToString();
        pawsText.text = GameObject.FindAnyObjectByType<PawsManager>().ReturnCurrentPaws().ToString() + " / " + GameObject.FindAnyObjectByType<PawsManager>().maxNumberOfPaws.ToString();

        switch (GameObject.FindAnyObjectByType<ScoreManager>().ReturnCurrentStarts())
        {

            case 1:
                {

                    fillStars[0].SetActive(true);

                break;
                }
            case 2:
                {

                    fillStars[1].SetActive(true);

                    break;
                }
            case 3:
                {

                    fillStars[2].SetActive(true);

                    break;
                }

        }

    }

    public void ButtonResume()
    {

        GameObject.FindFirstObjectByType<AudioManager>().StartSongTimer();
        pauseMenu.SetActive(false);

    }

    public void ButtonRestartLevel()
    {
        GameManager.Instance.LoadLevel(GameManager.Instance.levelData.levelID);
    }

    public void ButtonConfiguration()
    {
        


    }

    public void ButtonGoHome()
    {
        GameManager.Instance.LoadMainMenu();
    }
}
