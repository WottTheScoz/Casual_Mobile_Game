using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public delegate void TargetDelegate();
    public event TargetDelegate OnHit;

    AudioSource targetSound;

    private void Awake()
    {
        targetSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider)
    {
        
        if(collider.gameObject.tag == "Bullet")
        {
            targetSound.Play();
            OnHit?.Invoke();
            SetActivity(false);
        }
    }

    void SetActivity(bool activate)
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = activate;
        gameObject.GetComponent<MeshRenderer>().enabled = activate;
    }
}
