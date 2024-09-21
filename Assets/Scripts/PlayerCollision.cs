using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public string obstacleTag = "Obstacle";

    public delegate void PlayerCollisionDelegate();
    public event PlayerCollisionDelegate OnHitObstacle;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == obstacleTag)
        {
            OnHitObstacle?.Invoke();
            Debug.Log("Hit obstacle");
        }
    }
}
