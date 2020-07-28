using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emplacementAI : MonoBehaviour
{
    [Header("References")]
    public GameObject player;
    public GameObject ammunitionObj;
    public GameObject shootPoint;

    [Header("Stats")]
    public bool canSeePlayer;
    public float fireCooldownMax;
    private float fireCooldownTemp;
    
    // Start is called before the first frame update
    void Start()
    {
         fireCooldownTemp = fireCooldownMax;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(canSeePlayer == true)
        {
            transform.LookAt(player.transform.position, transform.up);
            shootPoint.transform.LookAt(player.transform.position, transform.up);

            if (fireCooldownTemp < 0)
            {
                Fire();
                fireCooldownTemp = fireCooldownMax;
            }
            else
            {
                fireCooldownTemp -= 1 * Time.deltaTime;
            }

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player Tank")
        {
            canSeePlayer = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player Tank")
        {
            canSeePlayer = false;
        }
    }

    public void Fire()
    {
        Instantiate(ammunitionObj, new Vector3(shootPoint.transform.position.x, shootPoint.transform.position.y, shootPoint.transform.position.z), shootPoint.transform.rotation);
        Debug.Log("emplacement fired !");
    }

}
