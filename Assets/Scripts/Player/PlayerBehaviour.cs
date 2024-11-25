using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public bool touchControls;
    public GameObject startNodeObj;
    public AnimationCurve curve;

    Vector3 moveDirection;

    Rigidbody rb;

    PlayerCollision collision;
    PlayerInputReader input;
    SwipeDetection swipeDetection;
    public TempAnim anim;

    Node prevNode;
    Node currentNode;
    Node nextNode;

    States currentState = States.Stationary;

    float elapsedTime;

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        // gets the player's rigidbody
        rb = GetComponent<Rigidbody>();

        // gets the player's collision script.
        collision = GetComponent<PlayerCollision>();

        // gets player input reader script
        input = GetComponent<PlayerInputReader>();

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
        if (currentState == States.Moving)
        {
            elapsedTime += Time.deltaTime;
            float percentCompleted = elapsedTime * 1f;
            NodeInterpolation(currentNode, nextNode, curve.Evaluate(percentCompleted));
            anim.WalkAnim();

            if (transform.position == nextNode.transform.position)
            {
                currentState = States.Stationary;
                prevNode = currentNode;
                currentNode = nextNode.GetComponent<Node>();
            }
        }
        else 
        {
            Stationary();
        }
    }
    #endregion

    #region Node System / Movement
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
        //prevNode = currentNode;
        //currentNode = targetNode.GetComponent<Node>();
        nextNode = targetNode.GetComponent<Node>();
       currentState = States.Moving;
    }

    void NodeInterpolation(Node beginNode, Node endNode, float percentCompleted) 
    {
        transform.position = Vector3.Lerp(beginNode.transform.position, endNode.transform.position, percentCompleted);
    }

    // Returns player to current node. Used by PlayerCollision
    void ToPrevNode()
    {
        currentState = States.Stationary;
        transform.position = currentNode.gameObject.transform.position;
    }
    #endregion

    #region Get Direction

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

    #region States

    void Stationary() 
    {
        UpdateMoveDirection();
        NodeMovement();

        if (elapsedTime != 0)
        {
            elapsedTime = 0;
        }
    }

    enum States 
    {
        Stationary,
        Moving
    }
    #endregion
}

