using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private HUDManager HUD;
    [SerializeField] private int currentScore = 0;
    [SerializeField] private int currentCombo = 0;

    public void UpdateScore(int addToScore)
    {
        // If the score to add is bigger than 0 - if the note was not a miss
        if(addToScore > 0)
        {
            if(currentCombo > 0)
            {

                addToScore *= currentCombo;

            }
            currentScore += addToScore;
            HUD.UpdateScoreText(currentScore);
            IncreaseCombo();

        }
        else
        {

            BreakCombo();

        }

    }

    private void IncreaseCombo()
    {

        currentCombo++;
        HUD.UpdateComboText(currentCombo);

    }

    private void BreakCombo()
    {

        currentCombo = 0;
        HUD.UpdateComboText(currentCombo);

    }
    
}
