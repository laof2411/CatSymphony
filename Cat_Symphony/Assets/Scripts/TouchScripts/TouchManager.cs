using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{

    private TouchActionAsset touchAsset;

    private InputAction touchPositionAction;
    private InputAction touchPressedAction;


    private void Awake()
    {
        touchAsset = new TouchActionAsset();
        touchPositionAction = touchAsset.Touch.SingleTapPosition;
        touchPressedAction = touchAsset.Touch.SingleTapPressed;
    }

    private void OnEnable()
    {
        touchPressedAction.performed += TouchPressed;
    }
    private void OnDisable()
    {
        touchPressedAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {

        float _value = context.ReadValue<float>();
        Debug.Log(_value);
    }

}
