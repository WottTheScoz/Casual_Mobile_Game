using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempAnim : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey(KeyCode.UpArrow))
        {
            //Send a message to the animator to activate the Walk trigger paramter
            //anim.SetTrigger("Shoot");


            
        }

        //if (Input.GetKey(KeyCode.DownArrow))
        {
            //Send a message to the animator to activate the Shoot trigger paramter
            //anim.SetTrigger("Walk");
        }
    }

    public void ShootAnim()
    {
        anim.SetTrigger("Shoot");
    }

    public void WalkAnim()
    {
        anim.SetTrigger("Walk");
    }
}
