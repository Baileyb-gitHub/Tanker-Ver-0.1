using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class missionManager : MonoBehaviour /// this class checks if all objects are complete or mission failure and then activates the relevent ui
{
    public string missionTitle;
    public string missionDescription;
    public List<Objective> missionObjectives;
    public GameObject player;
    [Header ("UI References")]
    public GameObject missionCompleteUI;
    public GameObject missionFailUI;
    public Text missionCompleteUIText;
    public Text missionFailUIText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     bool missionWon = true;

     foreach (Objective obj in missionObjectives)
     {
            if(obj.objectiveComplete == false)
            {
                obj.checkForCompletion();
                missionWon = false;
            }
            if (obj.objectiveFailed == true)
            {
                missionFailed("An objective was  Failed");
            }

     }

     if(missionWon == true)
     {
            missionComplete();
     }


     if(player.GetComponent<playerTankController>().health <= 0 || player.GetComponent<playerTankController>().fuel <= 0)
        {
            missionFailed("Tank ran our of Health/Fuel");
            player.GetComponent<playerTankController>().Die();
        }
    }


    public void missionComplete()
    {
        missionCompleteUI.SetActive(true);;
        Debug.Log("Mission Complete");
    }

    public void missionFailed(string reason)
    {
        missionFailUI.SetActive(true);
        Debug.Log("Mission Failed");
    }


}
