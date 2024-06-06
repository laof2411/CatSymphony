using UnityEngine;
using UnityEngine.EventSystems;

public class SingleTapNoteEvent : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private Transform transformObjective;

    public void OnPointerClick(PointerEventData eventData)
    {

        SingleTap();

    }    

    private void SingleTap()
    {

        FindFirstObjectByType<NoteTouchManager>().ProcessTap(transform,transformObjective);

    }

}
