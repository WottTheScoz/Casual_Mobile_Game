using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject startNodeObj;

    Node currentNode;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startNodeObj.transform.position;

        currentNode = startNodeObj.GetComponent<Node>();
    }

    // Update is called once per frame
    void Update()
    {
        NodeMovement();
    }

    // determines which node to move to and where it's located relative to current node
    void NodeMovement()
    {
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
        if (inputDirection == Vector3.up)
        {
            if (Input.GetKeyDown("w"))
            {
                ToNextNode(targetNode);
            }
        }
        else if (inputDirection == Vector3.down)
        {
            if (Input.GetKeyDown("s"))
            {
                ToNextNode(targetNode);
            }
        }
        else if (inputDirection == Vector3.right)
        {
            if (Input.GetKeyDown("d"))
            {
                ToNextNode(targetNode);
            }
        }
        else if (inputDirection == Vector3.left)
        {
            if (Input.GetKeyDown("a"))
            {
                ToNextNode(targetNode);
            }
        }
    }

    // Handles actual movement of the player to the next node
    void ToNextNode(GameObject targetNode)
    {
        transform.position = targetNode.transform.position;
        currentNode = targetNode.GetComponent<Node>();
    }
}
