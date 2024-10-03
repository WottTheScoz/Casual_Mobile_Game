using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeControls : MonoBehaviour
{
    float minimumSwipeMagnitude = 10f;

    Vector2 swipeDirection;

    Vector3 moveDirection = Vector3.zero;

    PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = new PlayerInput();

        playerInput.Player.Enable();

        playerInput.Player.Touch.canceled += ProcessTouchComplete;

        playerInput.Player.Swipe.performed += ProcessSwipeDelta;
    }

    void ProcessSwipeDelta(InputAction.CallbackContext context)
    {
        swipeDirection = context.ReadValue<Vector2>();
    }

    void ProcessTouchComplete(InputAction.CallbackContext context)
    {
        // check if magnitude is high enough
        if(Mathf.Abs(swipeDirection.magnitude) < minimumSwipeMagnitude)
        {
            return;
        }

        // check horizontal direction
        if(swipeDirection.x > 0)
        {
            moveDirection.x = 1;
        }
        else if(swipeDirection.x < 0)
        {
            moveDirection.x = -1;
        }

        // check vertical direction
        if(swipeDirection.y > 0)
        {
            moveDirection.z = 1;
        }
        else if(swipeDirection.y < 0)
        {
            moveDirection.z = -1;
        }
    }

    public Vector3 GetMoveDirection()
    {
        Vector3 tempDirection = moveDirection;
        moveDirection = Vector3.zero;
        return tempDirection;
    }
}
