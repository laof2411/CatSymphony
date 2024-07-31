using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndManager : MonoBehaviour
{

    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject songCanvas;
    [SerializeField] private PauseMenuManager pauseMenuManager;

    [SerializeField] private float waitingTime = 3;

    public void EndLevelPublicMethod()
    {

        Invoke(nameof(EndLevel), waitingTime);

    }

    private void EndLevel()
    {

        GameManager.Instance.PauseGame();
        pauseScreen.SetActive(true);
        pauseMenuManager.UpdatePauseData();
        songCanvas.SetActive(false);

    }


}
