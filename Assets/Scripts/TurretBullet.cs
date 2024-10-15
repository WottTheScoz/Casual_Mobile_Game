using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurretBullet : MonoBehaviour
{
    float maxTimer = 5;
    float bulletTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletTimer >= maxTimer)
        {
            Destroy(gameObject);
        }

        else
        {
            bulletTimer += 1 * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Destroy(gameObject);

        if(collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
