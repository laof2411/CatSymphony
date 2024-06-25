using UnityEngine;
using UnityEngine.EventSystems;

public class SingleTapNoteEvent : BaseNoteScript, IPointerClickHandler
{

    [SerializeField] private Transform transformObjective;

    public void OnPointerClick(PointerEventData eventData)
    {

        if (!hasBeenInteractedWith)
        {

            SingleTap();
            hasBeenInteractedWith = true;

        }


    }    

    private void SingleTap()
    {

        FindFirstObjectByType<NoteTouchManager>().ProcessTap(transform,transformObjective);

    }

}
