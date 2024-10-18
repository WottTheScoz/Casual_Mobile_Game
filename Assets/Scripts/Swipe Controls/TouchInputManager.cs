using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{

    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;

    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    #endregion

    PlayerInput playerControls;
    Camera mainCamera;

    void Awake()
    {
        playerControls = new PlayerInput();
        mainCamera = Camera.main;
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        playerControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        playerControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    void StartTouchPrimary(InputAction.CallbackContext context)
    {
        Vector2 position = playerControls.Touch.PrimaryPosition.ReadValue<Vector2>();
        if(OnStartTouch != null) OnStartTouch(Utils.ScreenToWorld(mainCamera, position), (float)context.startTime);
    }

    void EndTouchPrimary(InputAction.CallbackContext context)
    {
        Vector2 position = playerControls.Touch.PrimaryPosition.ReadValue<Vector2>();
        if(OnEndTouch != null) OnEndTouch(Utils.ScreenToWorld(mainCamera, position), (float)context.time);
    }

    public Vector2 PrimaryPosition()
    {
        Vector2 position = playerControls.Touch.PrimaryPosition.ReadValue<Vector2>();
        return Utils.ScreenToWorld(mainCamera, position);
    }
}
