using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject songSelectionScreen;
    [SerializeField] private GameObject dripStoreScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject creditsScreen;

    [SerializeField] private bool menuScreenHasBeenEntered;

    //Start is called before the first frame update
    void Start()
    {
        if (menuScreenHasBeenEntered == false)
        {
            OpenMainMenuScreen();
        }
        else
        {
            OpenSongSelectionScreen();
        }
    }

    void OpenMainMenuScreen()
    {
        HideAllScreens();
        mainMenuScreen.SetActive(true);

        menuScreenHasBeenEntered = true;
    }

    public void OpenSongSelectionScreen()
    {
        HideAllScreens();
        songSelectionScreen.SetActive(true);
    }

    public void OpenDripStoreScreen()
    {
        HideAllScreens();
        dripStoreScreen.SetActive(true);
    }

    public void OpenSettingsScreen()
    {
        HideAllScreens();
        settingsScreen.SetActive(true);
    }

    public void OpenCreditsScreen()
    {
        HideAllScreens();
        creditsScreen.SetActive(true);
    }

    public void HideAllScreens()
    {
        songSelectionScreen.SetActive(false);
        dripStoreScreen.SetActive(false);
        settingsScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }
}
