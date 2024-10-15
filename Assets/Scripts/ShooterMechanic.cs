using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMechanic : MonoBehaviour
{
    Rigidbody bullet;
    float maxTimer = 10;
    float regularTimer = 0;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        //bullet.AddForce(Vector3.forward, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (regularTimer >= maxTimer)
        {
            Destroy(bullet.gameObject);
        }
        else
        {
            regularTimer+= 1 * Time.deltaTime;
        }
    }

    public void shoot(Vector3 direction)
    { 
        bullet = GetComponent<Rigidbody>();
        bullet.AddForce(direction * speed, ForceMode.Impulse); 
       
    }

    // Destroys bullet upon collision. Makes an exception for the "Exception" tag.
    // "Exception" is for objects like portals.
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "Exception")
        {
            Destroy(bullet.gameObject);
        }
    }
}
