using UnityEngine;
using UnityEngine.EventSystems;

public class FreeStyleNoteEvent : BaseNoteScript, IPointerClickHandler 
{

    public void OnPointerClick(PointerEventData eventData)
    {

        FindFirstObjectByType<NoteTouchManager>().ProcessFreeStyleNote(this.transform);

    }

}
