using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTankController : tank
{
    [Header("Tank Parts")]
    public GameObject turret;
    public GameObject barrel;
    public GameObject shootPoint;
    public GameObject deathPart;


    [Header("Tank Stats")]
    public float turnSpeed;
    public float turretTurnSpeed;
    public float moveSpeed;
    public float reloadSpeed;
    public float reloadTemp;
    public float fuelTankSize;
    [Space]


    [Header("Tank Ammo")]
    public GameObject loadedRound;
    public int loadedRoundChoice;
    public bool reloading;
    [Space]
    public ammoloadout ammoSlot1;
    public ammoloadout ammoSlot2;


    [Header("Audio")]

    public AudioSource audioTurretTurn;
    public AudioSource audioTracks;
    public AudioSource audioFire;
    public AudioSource audioReload;
    public bool isMoving;// used to check if move audio should be played
    public bool isMovingTurret;// used to check if move audio should be played
    // Start is called before the first frame update

    [Header("Camera Handling")]

    public List<Camera> cameraList;
    private int camNum = 0;

    [Header("Menu Handling")]

    public GameObject missionUI;


    void Start()
    {

        reloadTemp = reloadSpeed;
        loadedRound = ammoSlot1.ammo;
        updateCams();
    }

    // Update is called once per frame
    void Update()
    {
        updateTankMovement();
        updateTurretMovement();
        updateActions();


       
        
    }


    public void updateTankMovement()
    {

        isMoving = false;   // defaults to no movement 

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<Rigidbody>().AddForce( - (transform.forward * moveSpeed) );
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(0.0f, -turnSpeed * Time.deltaTime, 0.0f, Space.Self);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(0.0f, turnSpeed * Time.deltaTime, 0.0f, Space.Self);
            isMoving = true;
        }

       if(isMoving == true)  // if player is moving start move audio, 
        {
            if(audioTracks.isPlaying == true)  // if its already playing do nothing
            {

            }
            else
            {
                audioTracks.Play();
            }
        }
        else  // if player not moving turn of move audio
        {
            if (audioTracks.isPlaying == true)
            {
                audioTracks.Stop();
            }
            else  // if its already turned off do nothing
            {
               
            }
        }




    }
    public void updateTurretMovement()
    {
        isMovingTurret = false;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turret.transform.Rotate(0.0f, -turretTurnSpeed * Time.deltaTime, 0.0f, Space.Self);
            isMovingTurret = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            turret.transform.Rotate(0.0f, turretTurnSpeed * Time.deltaTime, 0.0f, Space.Self);
            isMovingTurret = true;
        }




        Vector3 lastTurretRot = barrel.transform.localEulerAngles;// saves last rotation incase latest update exceedes boundaries

        if (Input.GetKey(KeyCode.UpArrow))
        {
            barrel.transform.Rotate(-turretTurnSpeed * Time.deltaTime, 0.0f, 0.0f, Space.Self);
            isMovingTurret = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            barrel.transform.Rotate(turretTurnSpeed * Time.deltaTime, 0.0f, 0.0f, Space.Self);
            isMovingTurret = true;
        }

        
        // 340 top max  5 low max
        if (barrel.transform.localEulerAngles.x < 340 && barrel.transform.localEulerAngles.x > 10)
        {

            float topDis = Mathf.Abs(340 - barrel.transform.localEulerAngles.x);
            float botDis = Mathf.Abs(10 - barrel.transform.localEulerAngles.x);

            barrel.transform.localEulerAngles = lastTurretRot;
        }



        if (isMovingTurret == true)  // if player is moving start move audio, 
        {
            if (audioTurretTurn.isPlaying == true)  // if its already playing do nothing
            {

            }
            else
            {
                audioTurretTurn.Play();
            }
        }
        else  // if player not moving turn of move audio
        {
            if (audioTurretTurn.isPlaying == true)
            {
                audioTurretTurn.Stop();
            }
            else  // if its already turned off do nothing
            {

            }
        }






    }
    
        
        
    public void updateActions()
    {


        //              NEW ACTIONS

        if (Input.GetKeyDown(KeyCode.Space) && reloading == false)
        {
            fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(reloading == false)  // dont initiate new reload if one is in progress
            {
                reload();
            }    
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            camNum += 1;
            if(camNum >= cameraList.Count)  // if cam num is higher than possible values return to first cammera
            {
                camNum = 0;
            }
            updateCams(); // disable and enable relevent cams based on new choice
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            updateMissionUI();
        }





        //          UPDATING ACTIONS

        if(reloading == true) // check progress if in middle ofreload
        {
            reloadTemp -= 1 * Time.deltaTime;
            if(reloadTemp < 0.1)
            {
                reloading = false;
                reloadTemp = reloadSpeed;
                audioReload.Stop();

                if (loadedRoundChoice == 1)
                {
                    loadedRound = ammoSlot1.ammo;

                }

                if (loadedRoundChoice == 2)
                {
                    loadedRound = ammoSlot2.ammo;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                loadedRoundChoice = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                loadedRoundChoice = 2;
            }
        }

        if (isMoving)
        {
            fuel -= 1 * Time.deltaTime;
        }
        


    }

    public void fire()
    {
        
        Instantiate(loadedRound, new Vector3(shootPoint.transform.position.x, shootPoint.transform.position.y, shootPoint.transform.position.z), shootPoint.transform.rotation);
        audioFire.Play();
        loadedRound = null;
    }

    public void reload()
    {

        if (loadedRoundChoice == 1 && ammoSlot1.ammoCount >= 1)
        {
          
            ammoSlot1.ammoCount -= 1;
            reloading = true; // triggers update reload mechanic
            audioReload.Play();

        }

        if (loadedRoundChoice == 2 && ammoSlot2.ammoCount >= 1)
        {
           ammoSlot2.ammoCount -= 1;
           reloading = true; // triggers update reload mechanic
            audioReload.Play();
        }


        
    }

    public override void Die()  // handles death of object
    {
        deathPart.SetActive(true);

        audioTurretTurn.Stop();
        audioTracks.Stop();
        audioFire.Stop();
        audioReload.Stop();

    enabled = false;
    }  
     
    public void updateCams()
    {
        foreach (Camera cam in cameraList)
        {
            cam.gameObject.SetActive(false);
        }
        cameraList[camNum].gameObject.SetActive(true);
    }   // swaps players cam view 

    public void updateMissionUI()
    {
     
      missionUI.SetActive(!missionUI.active);
       
    }  // opens and closes mission ui based on m key inpur




}
