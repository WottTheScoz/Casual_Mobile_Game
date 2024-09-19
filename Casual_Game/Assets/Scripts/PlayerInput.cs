using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameObject bullet; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
            
            bulletInstance.GetComponent<ShooterMechanic>().shoot(Vector3.forward);

            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);

            bulletInstance.GetComponent<ShooterMechanic>().shoot(Vector3.back);

            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);

            bulletInstance.GetComponent<ShooterMechanic>().shoot(Vector3.left);

            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);

            bulletInstance.GetComponent<ShooterMechanic>().shoot(Vector3.right);

            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
    }
}
