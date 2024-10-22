using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microchip : MonoBehaviour
{
    public GameObject objectToActivate;
    public AudioClip chipSound;

    // Start is called before the first frame update
    void Start()
    { 
        objectToActivate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.5f, 0);
    }

    void OnTriggerEnter(Collider collider)
    {
        
        if(collider.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(chipSound, transform.position);
            objectToActivate.SetActive(true);
            Destroy(gameObject);
        }
    }
}
