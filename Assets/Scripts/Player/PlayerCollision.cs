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

    private static PlayerCollision _instance;

    [SerializeField] private int _chips;

    void Start()
    {
        _chips = 0;
    }

    void Update()
    {
        UIManager.Instance.UpdateChipScore(_chips);
    }

    public static PlayerCollision Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Player is null");
            }
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    public void AddChips()
    {
        _chips++;
    }

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
