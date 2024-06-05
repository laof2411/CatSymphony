using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI sucessText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private TextMeshProUGUI scoreText;

    public void UpdateSuccessText(string stringToUse)
    {

        sucessText.text = stringToUse;

    }

    public void UpdateComboText(string stringToUse)
    {

        comboText.text = stringToUse;

    }

    public void UpdateScoreText(string stringToUse)
    {

        scoreText.text = stringToUse;

    }

    private IEnumerator FadeSuccessText()
    {

        return null;

    }

}
