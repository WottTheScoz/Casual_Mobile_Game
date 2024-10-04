using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalIn : MonoBehaviour
{
    public GameObject portalOut;
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            // Creates a new bullet instance at portalOut
            GameObject newBullet = Instantiate(other.gameObject, portalOut.transform.position, Quaternion.identity);

            // Gets the instance's script to give it velocity
            ShooterMechanic bulletScript = newBullet.gameObject.GetComponent<ShooterMechanic>();
            bulletScript.shoot(portalOut.transform.forward);

            // Destroys the original bullet
            Destroy(other.gameObject);
        }
    }
}
