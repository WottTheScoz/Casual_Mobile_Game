using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject startNodeObj;

    public bool usingTouchControls = false;

    Vector3 moveDirection;

    PlayerCollision collision;
    PlayerInputReader input;
    SwipeControls swipeInput;

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

        // gets swipe controls script
        swipeInput = gameObject.GetComponent<SwipeControls>();

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
    // INEFFICIENT: Will modify later on
    void InputToMovement(Vector3 inputDirection, GameObject targetNode)
    {
        /*if (inputDirection == Vector3.forward)
        {
            if (Input.GetKeyDown("w"))
            {
                ToNextNode(inputDirection, targetNode);
            }
        }
        else if (inputDirection == Vector3.back)
        {
            if (Input.GetKeyDown("s"))
            {
                ToNextNode(inputDirection, targetNode);
            }
        }
        else if (inputDirection == Vector3.right)
        {
            if (Input.GetKeyDown("d"))
            {
                ToNextNode(inputDirection, targetNode);
            }
        }
        else if (inputDirection == Vector3.left)
        {
            if (Input.GetKeyDown("a"))
            {
                ToNextNode(inputDirection, targetNode);
            }
        }*/

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
    void UpdateMoveDirection()
    {
        if(usingTouchControls)
        {
            moveDirection = swipeInput.GetMoveDirection();
        }
        else
        {
            moveDirection = input.GetMoveDirection();
        }
    }
    #endregion
}

