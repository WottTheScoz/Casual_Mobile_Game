using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Transform enemySpawnPoint;
    public GameObject enemyPrefab;
    public float enemySpeed = 5;

    public float maxTimer = 5;
    public float bufferOffset = 0;
    float currentTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentTimer -= bufferOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTimer >= maxTimer)
        {
            var enemy = Instantiate(enemyPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
            enemy.GetComponent<Rigidbody>().velocity = enemySpawnPoint.forward * enemySpeed;

            currentTimer = 0;
        }

        else
        {
            currentTimer += Time.deltaTime;
        }
    }
}
