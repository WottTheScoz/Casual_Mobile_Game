using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;

    PlayerInputReader inputReader;

    void Start()
    {
        inputReader = gameObject.GetComponent<PlayerInputReader>();                         // gets input reader to know when to shoot
        inputReader.OnShoot += Shoot;
    }

    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
            
        bulletInstance.GetComponent<ShooterMechanic>().shoot(transform.forward);
    }
}
