using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldTapNoteEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool isHoldingTouch = false;
    public bool firstTimeTouch = true;
    public float timer = 3f;

    [SerializeField] private Transform transformObjective;

    public void OnPointerDown(PointerEventData eventData)
    {

        FindFirstObjectByType<NoteTouchManager>().ProcessHoldTap(this.transform, transformObjective, timer <= 0);

    }

    public void OnPointerUp(PointerEventData eventData)
    {



    }

    private IEnumerator HoldPointer()
    {

        while(isHoldingTouch)
        {

            timer -= Time.deltaTime;
            

        }

        return null;
    }

}
