using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public void Scenenavigation(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

}
