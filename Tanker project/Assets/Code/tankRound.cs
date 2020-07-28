using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tankRound : MonoBehaviour
{
    public string ammoName;
    public float fireForce;
    public float damage;

    public Sprite Icon;
    public AudioClip hitSound;
    public GameObject particleAffect;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fireForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tank")
        {
            collision.gameObject.GetComponent<tank>().takeDamage(damage);
        }
        else if(collision.gameObject.tag == "DestructiveEnviro")
        {
            collision.gameObject.GetComponent<destructableEnviro>().takeDamage(damage);
            Debug.Log("Hit Enviro");
        }
        else if (collision.gameObject.tag == "Player Tank")
        {
            collision.gameObject.GetComponent<tank>().takeDamage(damage);
            Debug.Log("Hit Enviro");
        }
        else if (collision.gameObject.tag == "Emplacement")
        {

        }


        AudioSource.PlayClipAtPoint(hitSound, transform.position);
        Instantiate(particleAffect, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.LookRotation(new Vector3(0, 1, 0))  );
        Destroy(gameObject);
    }


}


