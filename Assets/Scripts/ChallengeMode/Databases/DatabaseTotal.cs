using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DatabaseTotal : MonoBehaviour
{
    public int maxDatabases = 4;
    public int nextScene;

    public void DecrementDatabase()
    {
        --maxDatabases;
        if(maxDatabases <= 0)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
