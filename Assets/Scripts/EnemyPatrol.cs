using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject[] patrolPoints;
    int current = 0;
    float rotSpeed;
    public float speed;
    float pointRadius = 1;


    // Update is called once per frame
    void Update()
    {
        if ((Vector2.Distance(patrolPoints[current].transform.position, transform.position) < pointRadius))
            {
            current++;
            if(current >= patrolPoints.Length)
            {
                current = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[current].transform.position, Time.deltaTime * speed);
    }
}
