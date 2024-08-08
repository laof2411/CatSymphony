using UnityEngine;
using UnityEngine.EventSystems;

public class BongoTouch : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private int bongoNumber;
    [SerializeField] private AnimationsManager animationManager;
    [SerializeField] private AudioManager audioManager;

    public void OnPointerClick(PointerEventData eventData)
    {

        if (!GameManager.Instance.isPaused)
        {

            animationManager.TapBongo(bongoNumber);
            audioManager.PlayBongoSound();


        }

    }

}
