using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    int current;
    public float speed;

    private void Start()
    {
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != patrolPoints[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[current].position, speed * Time.deltaTime);
        }

        else
        {
            current = (current + 1) % patrolPoints.Length;

            // Turns enemy around after reaching patrolpoint
            transform.rotation = Quaternion.LookRotation(transform.forward * -1);
        }
    }

}
