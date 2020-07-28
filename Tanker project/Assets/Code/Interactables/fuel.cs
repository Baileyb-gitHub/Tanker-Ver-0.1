using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuel : MonoBehaviour
{
    public float fuelValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tank")
        {
            collision.gameObject.GetComponent<playerTankController>().fuel += fuelValue;
            if (collision.gameObject.GetComponent<playerTankController>().fuel > collision.gameObject.GetComponent<playerTankController>().fuelTankSize)
            {
                collision.gameObject.GetComponent<playerTankController>().fuel = collision.gameObject.GetComponent<playerTankController>().fuelTankSize;
            }

        }
       
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tank")
        {
            other.gameObject.GetComponent<playerTankController>().fuel += fuelValue;
            if (other.gameObject.GetComponent<playerTankController>().fuel > other.gameObject.GetComponent<playerTankController>().fuelTankSize)
            {
                other.gameObject.GetComponent<playerTankController>().fuel = other.gameObject.GetComponent<playerTankController>().fuelTankSize;
            }
            Destroy(gameObject);
        }

       
    }


}
