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

        startingText.text = valueToUse;

        if(valueToUse == "Start")
        {

            startingText.gameObject.SetActive(false);

        }

    }

    public void OpenPauseMenu(GameObject button)
    {

        pauseMenu.SetActive(true);
        button.SetActive(false);

    }

    private IEnumerator FadeSuccessText()
    {

        return null;

    }

}
