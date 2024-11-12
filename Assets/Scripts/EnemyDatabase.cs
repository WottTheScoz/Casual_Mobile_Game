using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDatabase : MonoBehaviour
{
    public int maxHealth;
    public Healthbar healthbar;
    public GameObject DatabaseTotalObj;
    AudioSource hitSound;

    private int curHealth;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        hitSound = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        healthbar.UpdateHealth((float)curHealth / (float)maxHealth);

        if(curHealth == 0)
        {
            DatabaseTotalObj.GetComponent<DatabaseTotal>().DecrementDatabase();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            TakeDamage(2);
            hitSound.Play();
        }
    }
}
