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

            if (GameManager.Instance.levelData.firstStarScore > currentScore)
            {

                int percentage = GameManager.Instance.levelData.firstStarScore / currentScore;
                percentage /= 3;
                Debug.Log(percentage);

            }
            else if(GameManager.Instance.levelData.secondStarScore > currentScore)
            {

                int percentage = GameManager.Instance.levelData.secondStarScore / currentScore;
                percentage /= 3;
                percentage += 33;

            }
            else if(GameManager.Instance.levelData.thirdStarScore > currentScore)
            {

                int percentage = GameManager.Instance.levelData.thirdStarScore / currentScore;
                percentage /= 3;
                percentage += 66;
            }


            HUD.UpdateScoreUI(currentScore);
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
