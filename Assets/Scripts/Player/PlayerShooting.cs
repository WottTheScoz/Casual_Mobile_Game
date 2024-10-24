using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;

    PlayerInputReader inputReader;

    AudioSource gunSound;

    void Start()
    {
        inputReader = gameObject.GetComponent<PlayerInputReader>();                         // gets input reader to know when to shoot
        inputReader.OnShoot += Shoot;
        gunSound = GetComponent<AudioSource>();
    }

    void Shoot()
    {
        gunSound.Play();

        GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
            
        bulletInstance.GetComponent<ShooterMechanic>().shoot(transform.forward);
    }
}
