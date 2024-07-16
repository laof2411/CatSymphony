using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI sucessText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI pawsText;

    [SerializeField] private Image scoreFill;

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
        //scoreText.text = valueToUse.ToString();

    }

    public void UpdatePawsText(int valueToUse)
    {

        pawsText.text = valueToUse.ToString() + "/3";

    }

    private IEnumerator FadeSuccessText()
    {

        return null;

    }

}
