using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMissionDetails : MonoBehaviour  // this class updates the mission ui displayign progress to the player
{
    public missionManager missionManager;
    public Text missionTitleUI;
    public Text missionDescriptionUI;
    public Text objective1TitleUI;
    public Text objective1TitleDescriptionUI;
    public Text objective2TitleUI;
    public Text objective2TitleDescriptionUI;
    public Text objective3TitleUI;
    public Text objective3TitleDescriptionUI;
    // Start is called before the first frame update
    void Start()
    {
        missionTitleUI.text = missionManager.missionTitle;
        missionDescriptionUI.text = missionManager.missionDescription;
        objective1TitleDescriptionUI.text = missionManager.missionObjectives[0].objectiveDescription;
        objective2TitleDescriptionUI.text = missionManager.missionObjectives[1].objectiveDescription;
        objective3TitleDescriptionUI.text = missionManager.missionObjectives[2].objectiveDescription;
    }

    // Update is called once per frame
    void Update()
    {
        if(missionManager.missionObjectives[0].objectiveComplete == true)
        {
            objective1TitleUI.text = "Objective 1- " + missionManager.missionObjectives[0].objectiveTitle + "  COMPLETED";
        }
        else
        {
            objective1TitleUI.text = "Objective 1- " + missionManager.missionObjectives[0].objectiveTitle + "";
        }
    
        if (missionManager.missionObjectives[1].objectiveComplete == true)
        {
            objective2TitleUI.text = "Objective 2- " + missionManager.missionObjectives[0].objectiveTitle + "  COMPLETED";
        }
        else
        {
            objective2TitleUI.text = "Objective 2- " + missionManager.missionObjectives[0].objectiveTitle + "";
        }

        if (missionManager.missionObjectives[2].objectiveComplete == true)
        {
            objective3TitleUI.text = "Objective 3- " + missionManager.missionObjectives[0].objectiveTitle + "  COMPLETED";
        }
        else
        {
            objective3TitleUI.text = "Objective 3- " + missionManager.missionObjectives[0].objectiveTitle + "";
        }

    }




}
