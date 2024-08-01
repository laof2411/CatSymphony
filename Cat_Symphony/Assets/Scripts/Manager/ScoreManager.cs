using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private HUDManager HUD;
    [SerializeField] public int currentScore = 0;
    [SerializeField] private int currentCombo = 0;
    
    [SerializeField] private float percentage = 0;

    [SerializeField] private int currentStars = 0;
    [SerializeField] private AudioManager audioManager;

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

                percentage = (float)currentScore / (float)GameManager.Instance.levelData.firstStarScore;
                percentage /= 3;

                //currentStars = 0;

            }
            else if(GameManager.Instance.levelData.secondStarScore > currentScore)
            {

                percentage = (float)currentScore / (float)GameManager.Instance.levelData.secondStarScore;
                percentage /= 3;
                percentage *= 2;

                //currentStars = 1;
            }
            else if(GameManager.Instance.levelData.thirdStarScore > currentScore)
            {

                percentage = (float)currentScore / (float)GameManager.Instance.levelData.thirdStarScore;
               // currentStars = 2;
            }
            else
            {

                percentage = 1;
                //currentStars = 3;

            }

            HUD.UpdateScoreUI(percentage);

            IncreaseCombo();

        }
        else
        {

            BreakCombo();


        }


        if(GameManager.Instance.levelData.thirdStarScore < currentScore)
        {

            currentStars = 3;

        }
        else if(GameManager.Instance.levelData.secondStarScore  < currentScore)
        {

            currentStars = 2;

        }
        else if(GameManager.Instance.levelData.firstStarScore < currentScore)
        {

            currentStars = 1;

        }

        HUD.TurnOnStar(currentStars);

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
        audioManager.PlayFailComboSound();

    }

    public int ReturnCurrentScore()
    {

        return currentScore;

    }

    public int ReturnCurrentStars()
    {

        return currentStars;

    }
    
}
