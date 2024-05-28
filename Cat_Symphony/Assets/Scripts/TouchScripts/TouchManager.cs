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
        touchPositionAction.Enable();
        touchPressedAction.Enable();   
        touchPressedAction.performed += TouchPressed;
    }
    private void OnDisable()
    {
        touchPositionAction.Disable();
        touchPressedAction.Disable();
        touchPressedAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {

        //Vector3 _value = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
        Vector3 _value = touchPositionAction.ReadValue<Vector2>();
        
        Debug.Log(_value);
    }

}
