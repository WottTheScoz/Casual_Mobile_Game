using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePath : MonoBehaviour
{
    public GameObject baseNode;

    int nodeCount;

    [System.NonSerialized]
    public List<Transform> allNodes = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        nodeCount = transform.childCount;

        GetAllChildNodes();
    }

    // Update is called once per frame
    void Update()
    {
        if(nodeCount != transform.childCount)
        {
            GetAllChildNodes();
        }
    }

    public void GetAllChildNodes()
    {
        ClearNodesList();
        AddToNodesList();
    }

    void AddToNodesList()
    {
        // Re-adds all children
        for(int nodeIndex = 0; nodeIndex < nodeCount; ++nodeIndex)
        {
            allNodes.Add(transform.GetChild(nodeIndex));
        }
    }

    void ClearNodesList()
    {
        // Clears the node list
        allNodes.Clear();
    }

    #if UNITY_EDITOR
    // Gizmos that help visualize node path
    void OnDrawGizmos()
    {
        // Keeps up to date all children of NodePath object
        nodeCount = transform.childCount;
        GetAllChildNodes();

        // Creates a database of existing lines to decide on color
        List<LineCoords> repeatLines = new List<LineCoords>();

        // Draws a line between all connected nodes
        foreach(Transform node in allNodes)
        {
            // Compares the currently selected node to its connected nodes
            Node currentNode = node.gameObject.GetComponent<Node>();
            foreach(GameObject connectedNode in currentNode.connectedNodes)
            {
                Vector3 startPoint = currentNode.gameObject.transform.position;
                Vector3 endPoint = connectedNode.transform.position;

                // Turns line green if two nodes are connected to each other
                // Turns white if its a one-way connection
                foreach(LineCoords coordPair in repeatLines)
                {
                    if((coordPair.startPoint == startPoint || coordPair.startPoint == endPoint) && (coordPair.endPoint == startPoint || coordPair.endPoint == endPoint))
                    {
                        Gizmos.color = Color.green;
                        break;
                    }
                    else
                    {
                        Gizmos.color = Color.white;
                    }
                }

                Gizmos.DrawLine(startPoint, endPoint);

                // Adds line's coordinate paire to database of existing lines
                repeatLines.Add(new LineCoords(startPoint, endPoint));
            }
        }
    }
    #endif
}

// A line's coordinate pair. Used for drawing gizmos
public class LineCoords
{
    public Vector3 startPoint;
    public Vector3 endPoint;

    public LineCoords(){}

    public LineCoords(Vector3 newStartPoint, Vector3 newEndPoint)
    {
        startPoint = newStartPoint;
        endPoint = newEndPoint;
    }
}
