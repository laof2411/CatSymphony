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
    [SerializeField] private GameObject[] victoryStars;

    [SerializeField] private GameObject settingsObject;

    public void UpdatePauseData()
    {

        scoreText.text = "Score: " + GameObject.FindAnyObjectByType<ScoreManager>().ReturnCurrentScore().ToString();
        pawsText.text = GameObject.FindAnyObjectByType<PawsManager>().ReturnCurrentPaws().ToString() + " / " + GameObject.FindAnyObjectByType<PawsManager>().maxNumberOfPaws.ToString();

        Debug.Log("Stars: " + GameObject.FindAnyObjectByType<ScoreManager>().ReturnCurrentStars());

        switch (GameObject.FindAnyObjectByType<ScoreManager>().ReturnCurrentStars())
        {

            case 1:
                {

                    fillStars[0].SetActive(true);

                break;
                }
            case 2:
                {

                    fillStars[0].SetActive(true);
                    fillStars[1].SetActive(true);
                    break;
                }
            case 3:
                {
                    fillStars[0].SetActive(true);
                    fillStars[1].SetActive(true);
                    fillStars[2].SetActive(true);


                    break;
                }

        }
    }

    IEnumerator Umf(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        SoundManager.Instance.LaunchMusic("1");
    }

    public void LevelEndPause()
    {

        scoreText.text = "Score: " + GameObject.FindAnyObjectByType<ScoreManager>().ReturnCurrentScore().ToString();
        pawsText.text = GameObject.FindAnyObjectByType<PawsManager>().ReturnCurrentPaws().ToString() + " / " + GameObject.FindAnyObjectByType<PawsManager>().maxNumberOfPaws.ToString();

        fillStars[0].SetActive(false);
        fillStars[1].SetActive(false);
        fillStars[2].SetActive(false);

        switch (GameObject.FindAnyObjectByType<ScoreManager>().ReturnCurrentStars())
        {

            case 1:
                {
                    victoryStars[0].SetActive(true);

                    StartCoroutine(Umf(0.2f));
                    break;
                }
            case 2:
                {
                    victoryStars[0].SetActive(true);
                    victoryStars[1].SetActive(true);

                    StartCoroutine(Umf(0.2f));
                    StartCoroutine(Umf(1.2f));
                    StartCoroutine(Umf(2.2f));
                    break;
                }
            case 3:
                {
                    victoryStars[0].SetActive(true);
                    victoryStars[1].SetActive(true);
                    victoryStars[2].SetActive(true);

                    StartCoroutine(Umf(0.2f));
                    StartCoroutine(Umf(1.2f));
                    StartCoroutine(Umf(2.2f));
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
        
        settingsObject.SetActive(true);
        pauseMenu.SetActive(false);

    }

    public void ButtonGoHome()
    {
        GameManager.Instance.LoadMainMenu();
    }
}
