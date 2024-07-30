using UnityEngine.EventSystems;

public class FreeStyleNoteEvent : BaseNoteScript, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {

        if (!GameManager.Instance.isPaused)
        {

            FindFirstObjectByType<NoteTouchManager>().ProcessFreeStyleNote(this.transform);


        }

    }

}
