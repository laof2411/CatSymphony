using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private TextMeshProUGUI[] modifiableStats;
    [SerializeField] private int[] modifiableStatsInfo;

    public void UpdatePauseData()
    {

        //modifiableStats[0].text = "Score: " + modifiableStatsInfo[0];
        //modifiableStats[1].text = modifiableStatsInfo[1] + " / 3";
        //modifiableStats[2].text = "Other: " + modifiableStatsInfo[2];

    }

    public void ButtonResume()
    {

        GameObject.FindFirstObjectByType<AudioManager>().StartSongTimer();
        pauseMenu.SetActive(false);

    }

    public void ButtonRestartLevel()
    {
        //GameManager.Instance
    }

    public void ButtonConfiguration()
    {
        Debug.Log("Configuration");
    }

    public void ButtonGoHome()
    {
        GameManager.Instance.LoadMainMenu();
    }
}
