using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public float maxTimer = 10f;
    float timer;

    public GameObject gameOverCanvas;

    const float ZERO = 0;

    State timerState = State.Incomplete;

    public delegate void TimerDelegate(float timer);
    public event TimerDelegate OnCountdown;

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        DiscreteTimer();
    }
    #endregion

    #region Timer Logic

    // Timer that sets itself inactive upon completion
    void DiscreteTimer()
    {
        if(timerState != State.Complete)
        {
            if(timer >= ZERO)
            {
                timer -= Time.deltaTime;
                OnCountdown?.Invoke(timer);
            }
            else
            {
                timerState = State.Complete;
                GameOver();
            }
        }
    }

    void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    #endregion

    #region Enums
    enum State
    {
        Complete,
        Incomplete
    }
    #endregion
}
