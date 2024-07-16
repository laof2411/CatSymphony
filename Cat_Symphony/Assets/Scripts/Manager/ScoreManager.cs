using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private HUDManager HUD;
    [SerializeField] private int currentScore = 0;
    [SerializeField] private int currentCombo = 0;
    
    [SerializeField] private float percentage = 0;

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

                percentage = currentScore/GameManager.Instance.levelData.firstStarScore;
                percentage /= 3;
                Debug.Log("Primero");

            }
            else if(GameManager.Instance.levelData.secondStarScore > currentScore)
            {

                percentage = currentScore / GameManager.Instance.levelData.secondStarScore;
                percentage /= 3;
                percentage *= 2;
                Debug.Log("Segundo");

            }
            else if(GameManager.Instance.levelData.thirdStarScore > currentScore)
            {

                percentage = currentScore / GameManager.Instance.levelData.thirdStarScore;
                Debug.Log("Tercero");
            }
            else
            {

                percentage = 1;

            }
            Debug.Log(percentage);

            HUD.UpdateScoreUI(percentage);
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
