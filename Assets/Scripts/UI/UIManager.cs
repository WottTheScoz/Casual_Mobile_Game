using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public TMP_Text chipScore;
    public static UIManager Instance
    {
        get
        {
            if(_instance ==null)
            {
                Debug.Log("UIManager is null");
            }

            return _instance;
        }
    }

    public void UpdateChipScore(int _chips)
    {
        chipScore.text = " "+_chips;
    }

    void Awake()
    {
        _instance = this; 
    }
}
