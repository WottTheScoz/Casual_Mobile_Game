using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public string obstacleTag = "Obstacle";

    public GameObject pauseMenu;

    public GameObject gameOver;

    public delegate void PlayerCollisionDelegate();
    public event PlayerCollisionDelegate OnHitObstacle;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == obstacleTag)
        {
            OnHitObstacle?.Invoke();
        }

        /*if(collider.gameObject.tag == "Exit")
        {
            SceneManager.LoadScene("GameWin");
        }*/

        if(collider.gameObject.tag == "Enemy")
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }
    }
}
