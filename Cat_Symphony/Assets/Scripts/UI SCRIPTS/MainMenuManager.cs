using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] mainMenuScreen;
    [SerializeField] private GameObject[] songSelectionScreen;
    [SerializeField] private GameObject[] dripStoreScreen;
    [SerializeField] private GameObject[] settingsScreen;
    [SerializeField] private GameObject[] creditsScreen;

    [SerializeField] private GameObject[] sides;


    [SerializeField] private GameObject mainBackgroundObj;
    [SerializeField] private GameObject starterBackgroundObj;
    [SerializeField] private Sprite[] backgroundSprites = new Sprite[5];


    [SerializeField] private GameObject menusButtonHolderObj;

    //Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.menuScreenHasBeenEntered == false)
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
        for (int i = 0; i < mainMenuScreen.Length; i++)
        {
            mainMenuScreen[i].SetActive(true);
        }

        mainBackgroundObj.SetActive(false);
        starterBackgroundObj.SetActive(true);
        menusButtonHolderObj.SetActive(false);

        GameManager.Instance.menuScreenHasBeenEntered = true;
    }

    public void OpenSongSelectionScreen()
    {
        HideAllScreens();
        for (int i = 0; i < songSelectionScreen.Length; i++)
        {
            songSelectionScreen[i].SetActive(true);
        }
        mainBackgroundObj.SetActive(true);
        starterBackgroundObj.SetActive(false);

        mainBackgroundObj.GetComponent<Image>().sprite = backgroundSprites[1];
        menusButtonHolderObj.SetActive(true);

    }

    public void OpenDripStoreScreen()
    {
        HideAllScreens();
        for (int i = 0; i < dripStoreScreen.Length; i++)
        {
            dripStoreScreen[i].SetActive(true);
        }

        mainBackgroundObj.GetComponent<Image>().sprite = backgroundSprites[2];
        menusButtonHolderObj.SetActive(true);
    }

    public void OpenSettingsScreen()
    {
        HideAllScreens();
        for (int i = 0; i < settingsScreen.Length; i++)
        {
            settingsScreen[i].SetActive(true);
        }

        mainBackgroundObj.GetComponent<Image>().sprite = backgroundSprites[3];
        menusButtonHolderObj.SetActive(true);
    }

    public void OpenCreditsScreen()
    {
        HideAllScreens();
        for (int i = 0; i < creditsScreen.Length; i++)
        {
            creditsScreen[i].SetActive(true);
        }

        mainBackgroundObj.GetComponent<Image>().sprite = backgroundSprites[4];
        menusButtonHolderObj.SetActive(false);
    }

    public void HideAllScreens()
    {
        for (int i = 0; i < mainMenuScreen.Length; i++)
        {
            mainMenuScreen[i].SetActive(false);
        }
        for (int i = 0; i < songSelectionScreen.Length; i++)
        {
            songSelectionScreen[i].SetActive(false);
        }
        for (int i = 0; i < dripStoreScreen.Length; i++)
        {
            dripStoreScreen[i].SetActive(false);
        }
        for (int i = 0; i < settingsScreen.Length; i++)
        {
            settingsScreen[i].SetActive(false);
        }
        for (int i = 0; i < creditsScreen.Length; i++)
        {
            creditsScreen[i].SetActive(false);
        }
    }
}
