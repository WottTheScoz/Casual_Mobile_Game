using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrochipCollect : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerCollision.Instance.AddChips();
            Destroy(this.gameObject);
        }
    }

}
