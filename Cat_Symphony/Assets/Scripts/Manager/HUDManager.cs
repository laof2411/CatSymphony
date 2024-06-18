using System.Collections;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI sucessText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI pawsText;

    public void UpdateSuccessText(string stringToUse)
    {

        sucessText.text = stringToUse;

    }

    public void UpdateComboText(int valueToUse)
    {

        comboText.text = "x" + valueToUse.ToString();

    }

    public void UpdateScoreText(int valueToUse)
    {

        scoreText.text = valueToUse.ToString();

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
