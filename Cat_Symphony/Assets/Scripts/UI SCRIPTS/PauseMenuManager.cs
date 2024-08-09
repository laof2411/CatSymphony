using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI pawsText;

    [SerializeField] private GameObject[] fillStars;
    [SerializeField] private GameObject[] victoryStars;
    [SerializeField] private GameObject[] victorySparkles;
    [SerializeField] private GameObject[] victoryImage;

    [SerializeField] private GameObject settingsObject;

    //private void Start()
    //{
    //    StartCoroutine(Umf(2));
    //}

    public void UpdatePauseData()
    {

        scoreText.text = "Score: " + GameObject.FindAnyObjectByType<ScoreManager>().ReturnCurrentScore().ToString();
        pawsText.text = GameObject.FindAnyObjectByType<PawsManager>().ReturnCurrentPaws().ToString() + " / " + GameObject.FindAnyObjectByType<PawsManager>().maxNumberOfPaws.ToString();


        int stars = GameObject.FindAnyObjectByType<ScoreManager>().ReturnCurrentStars();
        Debug.Log("Stars: " + stars);

        switch (stars)
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

    IEnumerator Umf(int type)
    {
        //victoryStars[0].SetActive(true);
        //victoryStars[1].SetActive(true);
        //victoryStars[2].SetActive(true);

        yield return new WaitForSeconds(1.2f);


        victorySparkles[0].SetActive(false);
        victorySparkles[1].SetActive(false);
        victorySparkles[2].SetActive(false);



        switch (type)
        {
            case 0:
                {
                    victoryImage[0].SetActive(false);
                    victoryImage[1].SetActive(false);
                    victoryImage[2].SetActive(false);

                    SoundManager.Instance.PlaySound("1");
                    victoryImage[0].SetActive(true);
                    victorySparkles[0].SetActive(true);
                    break;
                }
            case 1:
                {
                    victoryImage[0].SetActive(false);
                    victoryImage[1].SetActive(false);
                    victoryImage[2].SetActive(false);

                    SoundManager.Instance.PlaySound("1");
                    victoryImage[0].SetActive(true);
                    victorySparkles[0].SetActive(true);

                    yield return new WaitForSeconds(1f);


                    victoryImage[0].SetActive(false);
                    victoryImage[1].SetActive(false);
                    victoryImage[2].SetActive(false);

                    SoundManager.Instance.PlaySound("1");
                    victoryImage[1].SetActive(true);
                    victorySparkles[1].SetActive(true);
                    break;
                }
            case 2:
                {
                    victoryImage[0].SetActive(false);
                    victoryImage[1].SetActive(false);
                    victoryImage[2].SetActive(false);

                    SoundManager.Instance.PlaySound("1");
                    victoryImage[0].SetActive(true);
                    victorySparkles[0].SetActive(true);

                    Debug.Log("1");

                    yield return new WaitForSeconds(1f);

                    victoryImage[0].SetActive(false);
                    victoryImage[1].SetActive(false);
                    victoryImage[2].SetActive(false);

                    SoundManager.Instance.PlaySound("1");
                    victoryImage[1].SetActive(true);
                    victorySparkles[1].SetActive(true);

                    Debug.Log("2");

                    yield return new WaitForSeconds(1f);

                    victoryImage[0].SetActive(false);
                    victoryImage[1].SetActive(false);
                    victoryImage[2].SetActive(false);

                    SoundManager.Instance.PlaySound("1");
                    victoryImage[2].SetActive(true);
                    victorySparkles[2].SetActive(true);

                    Debug.Log("3");
                    break;
                }
        }


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

                    StartCoroutine(Umf(0));
                    break;
                }
            case 2:
                {
                    victoryStars[0].SetActive(true);
                    victoryStars[1].SetActive(true);

                    StartCoroutine(Umf(1));
                    break;
                }
            case 3:
                {
                    victoryStars[0].SetActive(true);
                    victoryStars[1].SetActive(true);
                    victoryStars[2].SetActive(true);

                    StartCoroutine(Umf(2));
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
