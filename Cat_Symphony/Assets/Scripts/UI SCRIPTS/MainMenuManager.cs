using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject songSelectionScreen;
    [SerializeField] private GameObject dripStoreScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject creditsScreen;

    [SerializeField] private bool menuScreenHasBeenEntered;

    [SerializeField] private GameObject mainBackgroundObj;
    [SerializeField] private Sprite[] backgroundSprites = new Sprite[5];


    [SerializeField] private GameObject menusButtonHolderObj;

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

        mainBackgroundObj.GetComponent<Image>().sprite = backgroundSprites[0];
        menusButtonHolderObj.SetActive(false);

        menuScreenHasBeenEntered = true;
    }

    public void OpenSongSelectionScreen()
    {
        HideAllScreens();
        songSelectionScreen.SetActive(true);

        mainBackgroundObj.GetComponent<Image>().sprite = backgroundSprites[1];
        menusButtonHolderObj.SetActive(true);
    }

    public void OpenDripStoreScreen()
    {
        HideAllScreens();
        dripStoreScreen.SetActive(true);

        mainBackgroundObj.GetComponent<Image>().sprite = backgroundSprites[2];
        menusButtonHolderObj.SetActive(true);
    }

    public void OpenSettingsScreen()
    {
        HideAllScreens();
        settingsScreen.SetActive(true);

        mainBackgroundObj.GetComponent<Image>().sprite = backgroundSprites[3];
        menusButtonHolderObj.SetActive(true);
    }

    public void OpenCreditsScreen()
    {
        HideAllScreens();
        creditsScreen.SetActive(true);

        mainBackgroundObj.GetComponent<Image>().sprite = backgroundSprites[4];
        menusButtonHolderObj.SetActive(false);
    }

    public void HideAllScreens()
    {
        songSelectionScreen.SetActive(false);
        dripStoreScreen.SetActive(false);
        settingsScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }
}
