using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualLevelExit : MonoBehaviour
{
    public int SceneNumber;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            // go to next level
            SceneManager.LoadScene(SceneNumber);
        }
    }
}
