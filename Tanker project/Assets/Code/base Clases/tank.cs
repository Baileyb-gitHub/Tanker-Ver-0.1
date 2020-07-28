using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour
{
    [Header ("Tank Generics")]
    public float health;
    public float fuel;
    public string tankName;
    public string tankCommanderName;

    public List<string> commanderNameList;
    
   

    // Start is called before the first frame update
    void Start()
    {
        tankCommanderName = commanderNameList[Random.Range(0, commanderNameList.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    public void takeDamage(float damageReceived)
    {
        health -= damageReceived;
        if(health < 0.1)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }


}
