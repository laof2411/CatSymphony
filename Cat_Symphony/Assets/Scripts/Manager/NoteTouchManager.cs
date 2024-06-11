using UnityEngine;

public class NoteTouchManager : MonoBehaviour
{
    [SerializeField] private HUDManager HUD;
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private float missDistance;
    [SerializeField] private float okayDistance;
    [SerializeField] private float greatDistance;
    [SerializeField] private float purrfectDistance;

    [SerializeField] private int missScore;
    [SerializeField] private int okayScore;
    [SerializeField] private int greatScore;
    [SerializeField] private int purrfectScore;

    public void ProcessSingleTap(Transform noteTransform, Transform transformObjective)
    {

        Debug.Log(Vector3.Distance(transformObjective.position, noteTransform.position));

        if (Vector3.Distance(transformObjective.position, noteTransform.position) <= purrfectDistance)
        {

            HUD.UpdateSuccessText("Purrfect!");
            scoreManager.UpdateScore(purrfectScore);
            Destroy(noteTransform.gameObject);

        }
        else if (Vector3.Distance(transformObjective.position, noteTransform.position) <= greatDistance)
        {

            HUD.UpdateSuccessText("Great");
            scoreManager.UpdateScore(greatScore);
            Destroy(noteTransform.gameObject);

        }
        else if (Vector3.Distance(transformObjective.position, noteTransform.position) <= okayDistance)
        {

            HUD.UpdateSuccessText("Okay");
            scoreManager.UpdateScore(okayScore);
            Destroy(noteTransform.gameObject);

        }
        else
        {

            HUD.UpdateSuccessText("Miss");
            Destroy(noteTransform.gameObject);

        }

    }

    public void ProcessHoldTap(Transform noteTransform, Transform transformObjective, bool endOfNote)
    {

        if (Vector3.Distance(transformObjective.position, noteTransform.position) <= purrfectDistance)
        {

            HUD.UpdateSuccessText("Purrfect!");
            scoreManager.UpdateScore(purrfectScore);
            //Destroy(noteTransform.gameObject);
        }
        else if (Vector3.Distance(transformObjective.position, noteTransform.position) <= greatDistance)
        {

            HUD.UpdateSuccessText("Great");
            scoreManager.UpdateScore(greatScore);
            //Destroy(noteTransform.gameObject);

        }
        else if (Vector3.Distance(transformObjective.position, noteTransform.position) <= okayDistance)
        {

            HUD.UpdateSuccessText("Okay");
            scoreManager.UpdateScore(okayScore);
            //Destroy(noteTransform.gameObject);

        }
        else
        {

            HUD.UpdateSuccessText("Miss");
            //Destroy(noteTransform.gameObject);

        }

    }

}
