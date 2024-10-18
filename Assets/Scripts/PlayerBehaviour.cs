using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public bool touchControls;
    public GameObject startNodeObj;

    Vector3 moveDirection;

    PlayerCollision collision;
    PlayerInputReader input;
    SwipeDetection swipeDetection;

    Node prevNode;
    Node currentNode;

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        // gets the player's collision script.
        collision = gameObject.GetComponent<PlayerCollision>();

        // gets player input reader script
        input = gameObject.GetComponent<PlayerInputReader>();

        // gets swipe detection script
        swipeDetection = GetComponent<SwipeDetection>();

        // sets listeners to subscribers
        collision.OnHitObstacle += ToPrevNode;

        // sets player to starting node
        transform.position = startNodeObj.transform.position;
        currentNode = startNodeObj.GetComponent<Node>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoveDirection();
        NodeMovement();
    }
    #endregion

    #region Node System
    // determines which node to move to and where it's located relative to current node
    void NodeMovement()
    {
        // Cycles through each connected node and checks for a corresponding input each frame
        foreach (GameObject targetNode in currentNode.connectedNodes)
        {
            Vector3 direction = targetNode.transform.position - currentNode.gameObject.transform.position;
            direction.Normalize();

            InputToMovement(direction, targetNode);
        }
    }

    // Calls movement depending on player input
    void InputToMovement(Vector3 inputDirection, GameObject targetNode)
    {
        if(inputDirection == moveDirection)
        {
            ToNextNode(inputDirection, targetNode);
        }
    }

    // Handles actual movement of the player to the next node
    void ToNextNode(Vector3 inputDirection, GameObject targetNode)
    {
        transform.position = targetNode.transform.position;
        prevNode = currentNode;
        currentNode = targetNode.GetComponent<Node>();
    }

    // Returns player to previous node. Used by PlayerCollision
    void ToPrevNode()
    {
        transform.position = prevNode.gameObject.transform.position;
        currentNode = prevNode;
    }
    #endregion

    #region Movement

    // Gets the direction of the player's input (WASD/Swipe up, down, left, right)
    Vector3 UpdateMoveDirection()
    {
        if(touchControls)
        {
            moveDirection = swipeDetection.GetMoveDirection();
        }
        else
        {
            moveDirection = input.GetMoveDirection();
        }

        Rotate(moveDirection);

        return moveDirection;
    }

    void Rotate(Vector3 direction)
    {
        if(direction.magnitude != 0)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
    #endregion
}

