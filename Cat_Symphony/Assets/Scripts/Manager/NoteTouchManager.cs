using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteTouchManager : MonoBehaviour
{
    [SerializeField] private HUDManager HUD;

    [SerializeField] private float missDistance;
    [SerializeField] private float okayDistance;
    [SerializeField] private float greatDistance;
    [SerializeField] private float purrfectDistance;

    public void ProcessTap(Transform noteTransform, Transform transformObjective)
    {

        if (Vector3.Distance(transformObjective.position, noteTransform.position) <= purrfectDistance)
        {

            HUD.UpdateSuccessText("Purrfect!");
            Destroy(gameObject);

        }
        else if (Vector3.Distance(transformObjective.position, noteTransform.position) <= greatDistance)
        {

            HUD.UpdateSuccessText("Great");
            Destroy(gameObject);

        }
        else if (Vector3.Distance(transformObjective.position, noteTransform.position) <= okayDistance)
        {

            HUD.UpdateSuccessText("Okay");
            Destroy(gameObject);

        }
        else
        {

            HUD.UpdateSuccessText("Miss");
            Destroy(gameObject);

        }

    }

}
