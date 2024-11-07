using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    public GameObject levelTimerObj;

    //int timerVal;

    TextMeshProUGUI tmpro;

    LevelTimer levelTimer;

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        tmpro = GetComponent<TextMeshProUGUI>();

        levelTimer = levelTimerObj.GetComponent<LevelTimer>();
        levelTimer.OnCountdown += Countdown;
    }
    #endregion

    #region Modify Display Text

    // Receives notification that timer is counting down
    void Countdown(float timer)
    {
        int timerVal = (int)timer;
        ChangeText(timerVal);
    }

    // Changes on-screen text to display timer
    void ChangeText(int timerVal)
    {
        tmpro.text = timerVal.ToString();
    }
    #endregion
}
