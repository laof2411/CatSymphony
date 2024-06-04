using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SingleTapNoteEvent : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private Transform transformObjective;
    [SerializeField] private TextMeshProUGUI UItext;

    [SerializeField] private float missDistance;
    [SerializeField] private float okayDistance;
    [SerializeField] private float greatDistance;
    [SerializeField] private float purrfectDistance;

    public void OnPointerClick(PointerEventData eventData)
    {

        SingleTap();

    }    

    private void SingleTap()
    {

        if(Vector3.Distance(transformObjective.position, transform.position) <= purrfectDistance)
        {

            UItext.text = "Purrfect";
            Destroy(gameObject);

        }
        else if(Vector3.Distance(transformObjective.position, transform.position) <= greatDistance)
        {

            UItext.text = "Great";
            Destroy(gameObject);

        }
        else if (Vector3.Distance(transformObjective.position, transform.position) <= okayDistance)
        {

            UItext.text = "Okay";
            Destroy(gameObject);

        }
        else
        {

            UItext.text = "Miss";
            Destroy(gameObject);

        }

    }

}
