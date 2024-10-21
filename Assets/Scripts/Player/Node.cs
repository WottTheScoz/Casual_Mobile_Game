using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool isObstacle = false;

    public GameObject connectedTarget;

    public List<GameObject> connectedNodes = new List<GameObject>();

    void Start()
    {
        if(isObstacle)
        {
            DeleteConnections();

            // Subscribes to corresponding target
            connectedTarget.GetComponent<Target>().OnHit += RestoreConnections;
        }
    }

    #region Obstacle Node Logic
    // Makes this node inaccessible by player
    void DeleteConnections()
    {
        // Deletes each instance of this object in connectedNodes
        foreach(GameObject nodeObj in connectedNodes)
        {
            Node node = nodeObj.GetComponent<Node>();
            var thisNode = node.connectedNodes.Find(altNode => altNode.name == gameObject.name);
            node.connectedNodes.Remove(thisNode);
        }
    }

    // Makes this node accessible to player
    void RestoreConnections()
    {
        // Reintroduces itself into each connected node's connectedNode list
        foreach(GameObject nodeObj in connectedNodes)
        {
            Node node = nodeObj.GetComponent<Node>();
            node.connectedNodes.Add(gameObject);
        }

        // Unsubs from corresponding target
        connectedTarget.GetComponent<Target>().OnHit -= RestoreConnections;
    }
    #endregion
}
