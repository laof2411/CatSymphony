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

        FindFirstObjectByType<NoteTouchManager>().ProcessTap(transform,transformObjective);

    }

}
