using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructableEnviro : MonoBehaviour
{

    public float health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damageReceived)
    {
        health -= damageReceived;
        if (health < 0.1)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

}
