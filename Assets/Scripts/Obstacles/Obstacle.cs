using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject connectedTarget;

    // Start is called before the first frame update
    void Start()
    {
        connectedTarget.GetComponent<Target>().OnHit += DestroySelf;
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
