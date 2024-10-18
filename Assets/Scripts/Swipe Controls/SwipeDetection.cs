using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField]
    float minimumDistance = 0.2f;
    [SerializeField]
    float maximumTime = 1f;
    [SerializeField, Range(0f, 1f)]
    float directionThreshold = 0.9f;

    InputManager inputManager;

    Vector2 startPosition;
    float startTime;
    Vector2 endPosition;
    float endTime;

    Vector3 moveDirection = new Vector3(0, 0, 0);

    #region Unity Methods
    void Awake()
    {
        //inputManager = InputManager.Instance;
        inputManager = GetComponent<InputManager>();
    }

    void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }
    #endregion
    
    #region Swipe Detection
    void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }

    void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    void DetectSwipe()
    {
        float distance = Vector3.Distance(startPosition, endPosition);
        float time = endTime - startTime;

        if((distance >= minimumDistance) && (time <= maximumTime))
        {
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;

            SwipeDirection(direction2D);
        }
    }
    #endregion

    #region Get Swipe Direction

    // Modifies moveDirection value after successful swipe
    void SwipeDirection(Vector2 direction)
    {
        Vector2[] diagonals = 
        {
            new Vector2(1, 1),
            new Vector2(-1, 1),
            new Vector2(1, -1),
            new Vector2(-1, -1)
        };

        // compares each diagonal direction to the given swipe direction using dot product and directionThreshold
        // calls SwipeCipher when a close enough match is found
        foreach(Vector2 diagonal in diagonals)
        {
            if(Vector2.Dot(diagonal, direction) > directionThreshold)
            {
                SwipeCipher(diagonal);
                break;
            }
        }
    }

    // deciphers the 2D direction of the swipe to a corresponding 3D coordinate
    void SwipeCipher(Vector2 direction2D)
    {
        Vector3 newDirection;

        if((direction2D.x + direction2D.y) != 0)
        {
            newDirection = new Vector3(0, 0, direction2D.x);
        }
        else
        {
            newDirection = new Vector3(direction2D.x, 0, 0);
        }

        moveDirection = newDirection;
    }

    // public getter for moveDirection. Done this way to retain GetMoveDirection naming convention.
    public Vector3 GetMoveDirection()
    {
        return moveDirection;
    }
    #endregion
}