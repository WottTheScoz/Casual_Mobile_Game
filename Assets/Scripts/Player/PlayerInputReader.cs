using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public PlayerInput playerControls;

    public delegate void InputDelegate();
    public event InputDelegate OnShoot;

    InputAction move;
    InputAction fire;
    InputAction touchFire;

    #region On Enable/Disable
    void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.canceled += Shoot;

        touchFire = playerControls.Touch.Fire;
        touchFire.Enable();
        touchFire.canceled += Shoot;
    }

    void OnDisable()
    {
        move.Disable();
        fire.Disable();
        touchFire.Disable();
    }
    #endregion

    #region Unity Methods
    void Awake()
    {
        playerControls = new PlayerInput();
    }
    #endregion

    #region Input Actions
    void Shoot(InputAction.CallbackContext context)
    {
        OnShoot?.Invoke();
    }

    public Vector3 GetMoveDirection()
    {
        Vector3 moveDirection;

        // Gets 2D move direction
        Vector2 moveDirection2D = move.ReadValue<Vector2>();

        // Converts 2D direction to 3D
        moveDirection = (Vector3)moveDirection2D;

        // Converts Y-axis direction to Z-axis direction
        if(moveDirection.y != 0)
        {
            float magnitude = moveDirection.y;
            moveDirection = Vector3.forward * magnitude;
        }

        return moveDirection;
    }
    #endregion
}
