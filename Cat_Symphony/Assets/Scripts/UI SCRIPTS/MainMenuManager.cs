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

    [SerializeField] private Sprite[] selectedSprites = new Sprite[3];
    [SerializeField] private Sprite[] unSelectedSprites = new Sprite[3];

    [SerializeField] private GameObject[] moveThroughHighlight = new GameObject[3];
    [SerializeField] private GameObject[] moveThroughMainMenuNormal = new GameObject[3];

    //Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.LaunchMusic("0");

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

        SoundManager.Instance.LaunchMusic("1");
    }

    public void OpenSongSelectionScreen()
    {
        HideAllScreens();
        HideButtonsHighlights();
        for (int i = 0; i < songSelectionScreen.Length; i++)
        {
            songSelectionScreen[i].SetActive(true);
        }
        mainBackgroundObj.SetActive(true);
        starterBackgroundObj.SetActive(false);

        moveThroughHighlight[0].SetActive(true);
        moveThroughMainMenuNormal[0].GetComponent<Image>().sprite = selectedSprites[0];
        moveThroughMainMenuNormal[1].GetComponent<Image>().sprite = unSelectedSprites[1];
        moveThroughMainMenuNormal[2].GetComponent<Image>().sprite = unSelectedSprites[2];

        mainBackgroundObj.GetComponent<Image>().sprite = backgroundSprites[1];
        menusButtonHolderObj.SetActive(true);
    }

    public void OpenDripStoreScreen()
    {
        HideAllScreens();
        HideButtonsHighlights();
        for (int i = 0; i < dripStoreScreen.Length; i++)
        {
            dripStoreScreen[i].SetActive(true);
        }

        moveThroughHighlight[1].SetActive(true);
        moveThroughMainMenuNormal[0].GetComponent<Image>().sprite = unSelectedSprites[0];
        moveThroughMainMenuNormal[1].GetComponent<Image>().sprite = selectedSprites[1];
        moveThroughMainMenuNormal[2].GetComponent<Image>().sprite = unSelectedSprites[2];

        mainBackgroundObj.GetComponent<Image>().sprite = backgroundSprites[2];
        menusButtonHolderObj.SetActive(true);
    }

    public void OpenSettingsScreen()
    {
        HideAllScreens();
        HideButtonsHighlights();
        for (int i = 0; i < settingsScreen.Length; i++)
        {
            settingsScreen[i].SetActive(true);
        }

        moveThroughHighlight[2].SetActive(true);
        moveThroughMainMenuNormal[0].GetComponent<Image>().sprite = unSelectedSprites[0];
        moveThroughMainMenuNormal[1].GetComponent<Image>().sprite = unSelectedSprites[1];
        moveThroughMainMenuNormal[2].GetComponent<Image>().sprite = selectedSprites[2];

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

    public void HideButtonsHighlights()
    {
        for (int i = 0; i < 3; i++)
        {
            moveThroughHighlight[i].SetActive(false);
        }
    }

    public void HideAllScreens()
    {
        SoundManager.Instance.LaunchMusic("6");

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
