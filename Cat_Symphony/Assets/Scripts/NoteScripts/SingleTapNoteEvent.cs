using UnityEngine;
using UnityEngine.EventSystems;

public class SingleTapNoteEvent : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    
    public void OnPointerClick(PointerEventData eventData)
    {

        SingleTap();

    }

    public void OnPointerDown(PointerEventData eventData)
    {

        SingleTap();

    }

    private void SingleTap()
    {

        Destroy(gameObject);

    }

}
