using UnityEngine;
using UnityEngine.EventSystems;

public class HoldTapNoteEvent : BaseNoteScript, IPointerDownHandler, IPointerUpHandler
{

    public bool isFirstNote = true;
    public bool firstTimeTouch = true;

    [SerializeField] public Transform transformObjective;
    [SerializeField] public HoldTapNoteEvent otherNote;

    [SerializeField] private LayerMask layerMask;

    public override void Start()
    {

        if (isFirstNote)
        {

            if (hasPaw)
            {

                pawObject.SetActive(true);

            }

        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (isFirstNote && firstTimeTouch && !hasBeenInteractedWith && !GameManager.Instance.isPaused)
        {

            FindFirstObjectByType<NoteTouchManager>().ProcessTap(this.transform, transformObjective);
            firstTimeTouch = false;
            otherNote.firstTimeTouch = false;
            hasBeenInteractedWith = true;

        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {

        Ray ray = Camera.main.ScreenPointToRay(eventData.position);

        if (!firstTimeTouch)
        {
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
            {
                if (hit.transform.gameObject == otherNote.gameObject && otherNote.hasBeenInteractedWith == false && !GameManager.Instance.isPaused)
                {

                    FindFirstObjectByType<NoteTouchManager>().ProcessTap(otherNote.transform, transformObjective);
                    otherNote.hasBeenInteractedWith = true;

                }

            }
        }
    }

}
