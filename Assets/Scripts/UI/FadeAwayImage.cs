using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeAwayImage : MonoBehaviour
{
    public float fadeTime;
    private Image fadeAwayImage;
    public float alphaValue;
    public float fadeAwayPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        fadeAwayImage = GetComponent<Image>();
        fadeAwayPerSecond = 1 / fadeTime;
        alphaValue = fadeAwayImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeTime > 0)
        {
            alphaValue -= fadeAwayPerSecond * Time.deltaTime;
            fadeAwayImage.color = new Color(fadeAwayImage.color.r, fadeAwayImage.color.g, fadeAwayImage.color.b, alphaValue);
            fadeTime -= Time.deltaTime;
        }
    }
}
