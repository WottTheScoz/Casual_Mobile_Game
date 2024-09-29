using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;

    PlayerInputReader inputReader;

    Camera mainCam;

    void Start()
    {
        inputReader = gameObject.GetComponent<PlayerInputReader>();
        inputReader.OnShoot += Shoot;

        mainCam = Camera.main;
    }

    void Shoot(Vector3 shootDirection)
    {
        Event currentEvent = Event.current;
        Vector3 point;

        point = mainCam.ScreenToWorldPoint(shootDirection);
        point.Normalize();
        point.y = 0;

        GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
            
        bulletInstance.GetComponent<ShooterMechanic>().shoot(point);
        transform.rotation = Quaternion.LookRotation(point);
    }
}
