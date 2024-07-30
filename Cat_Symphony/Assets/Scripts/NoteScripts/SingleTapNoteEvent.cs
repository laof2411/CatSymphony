using UnityEngine;
using UnityEngine.EventSystems;

public class SingleTapNoteEvent : BaseNoteScript, IPointerClickHandler
{

    [SerializeField] public Transform transformObjective;

    public void OnPointerClick(PointerEventData eventData)
    {


        if (!hasBeenInteractedWith && !GameManager.Instance.isPaused)
        {

            SingleTap(); hasBeenInteractedWith = true;

        }


    }

    private void SingleTap()
    {

        FindFirstObjectByType<NoteTouchManager>().ProcessTap(transform, transformObjective);

    }

}
