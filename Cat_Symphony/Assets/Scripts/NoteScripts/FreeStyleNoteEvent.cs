using UnityEngine;
using UnityEngine.EventSystems;

public class FreeStyleNoteEvent : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {

        FindFirstObjectByType<NoteTouchManager>().ProcessFreeStyleNote(this.transform);

    }

}
