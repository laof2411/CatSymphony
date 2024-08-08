using UnityEngine;

public class NoteTouchManager : MonoBehaviour
{
    [SerializeField] private HUDManager HUD;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private AnimationsManager animationsManager;
    [SerializeField] private AudioManager audioManager;

    [SerializeField] private float missDistance;
    [SerializeField] private float okayDistance;
    [SerializeField] private float greatDistance;
    [SerializeField] private float purrfectDistance;

    [SerializeField] private int missScore;
    [SerializeField] private int okayScore;
    [SerializeField] private int greatScore;
    [SerializeField] private int purrfectScore;

    public void ProcessTap(Transform noteTransform, Transform transformObjective)
    {

        if (Vector3.Distance(transformObjective.position, noteTransform.position) <= purrfectDistance)
        {

            HUD.UpdateSuccessText("Purrfect!");
            scoreManager.UpdateScore(purrfectScore);
            noteTransform.GetComponent<BaseNoteScript>().CheckForPaw();
            animationsManager.TapBongo(noteTransform.GetComponent<BaseNoteScript>().trailNumber);
            audioManager.PlayBongoSound();
            animationsManager.StartParticles(noteTransform.GetComponent<BaseNoteScript>().trailNumber);

        }
        else if (Vector3.Distance(transformObjective.position, noteTransform.position) <= greatDistance)
        {

            HUD.UpdateSuccessText("Great");
            scoreManager.UpdateScore(greatScore);
            noteTransform.GetComponent<BaseNoteScript>().CheckForPaw();
            animationsManager.TapBongo(noteTransform.GetComponent<BaseNoteScript>().trailNumber);
            audioManager.PlayBongoSound();
            animationsManager.StartParticles(noteTransform.GetComponent<BaseNoteScript>().trailNumber);

        }
        else if (Vector3.Distance(transformObjective.position, noteTransform.position) <= okayDistance)
        {

            HUD.UpdateSuccessText("Okay");
            scoreManager.UpdateScore(okayScore);
            noteTransform.GetComponent<BaseNoteScript>().CheckForPaw();
            animationsManager.TapBongo(noteTransform.GetComponent<BaseNoteScript>().trailNumber);
            audioManager.PlayBongoSound();
            animationsManager.StartParticles(noteTransform.GetComponent<BaseNoteScript>().trailNumber);

        }
        else
        {

            HUD.UpdateSuccessText("Miss");
            scoreManager.UpdateScore(missScore);


        }

    }

    public void ProcessFreeStyleNote(Transform noteTransform)
    {

        HUD.UpdateSuccessText("Okay");
        scoreManager.UpdateScore(okayScore);

    }

    public void InstaMissNote()
    {

        HUD.UpdateSuccessText("Miss");
        scoreManager.UpdateScore(missScore);

    }

}
