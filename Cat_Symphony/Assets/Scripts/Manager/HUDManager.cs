using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI sucessText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI pawsText;

    [SerializeField] private TextMeshProUGUI startingText;

    [SerializeField] private Image scoreFill;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;

    [SerializeField] private GameObject[] fillStars;
    [SerializeField] private PauseMenuManager pauseManager;

    public void UpdateSuccessText(string stringToUse)
    {

        sucessText.text = stringToUse;

    }

    public void UpdateComboText(int valueToUse)
    {

        comboText.text = "x" + valueToUse.ToString();

    }

    public void UpdateScoreUI(float percentageAmount)
    {

        scoreFill.fillAmount = percentageAmount;

    }

    public void UpdatePawsText(int valueToUse)
    {

        pawsText.text = valueToUse.ToString() + "/3";

    }

    public void UpdateStartingText(string valueToUse)
    {

        startingText.gameObject.SetActive(true);
        startingText.text = valueToUse;

        if(valueToUse == "Start")
        {

            pauseButton.SetActive(true);
            startingText.gameObject.SetActive(false);

        }

    }

    public void OpenPauseMenu()
    {

        pauseMenu.SetActive(true);
        pauseManager.UpdatePauseData();
        pauseButton.SetActive(false);
        GameManager.Instance.PauseGame();

    }

    public void TurnOnStar(int starToFill)
    {

        switch(starToFill)
        {

            case 1:
                fillStars[0].SetActive(true);
                break;
            case 2:
                fillStars[1].SetActive(true);
                break;
            case 3:
                fillStars[2].SetActive(true);
                break;

        }

    }

    //The sucess text should fade away after a few seconds of not touching the screen, will finish later.

    private IEnumerator FadeSuccessText()
    {
        float alphaValue = 1f;

        while(true)
        {
            alphaValue -= Time.deltaTime;
            sucessText.color = new Color(sucessText.color.r, sucessText.color.g, sucessText.color.b,alphaValue);
            return null;
        }


    }

}
