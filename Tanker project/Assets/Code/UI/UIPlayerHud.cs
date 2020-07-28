using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHud : MonoBehaviour
{
    public playerTankController player;

    [Header("UI Left Hud (HP & Fuel) References")]
    public Text armourText;
    public Text fuelText;
    public Text ammoState;

    [Header("UI right Hud (Ammo) References")]
    public Image ammo1Image;
    public Text ammo1Name;
    public Text ammo1Count;
    public Text ammo1Selected;

    public Image ammo2Image;
    public Text ammo2Name;
    public Text ammo2Count;
    public Text ammo2Selected;

    // Start is called before the first frame update
    void Start()
    {
        //player.fuel
    }

    // Update is called once per frame
    void Update()
    {
        armourText.text = ("Armour - " + player.health);
        fuelText.text = ("Fuel - " + System.Math.Round(player.fuel, 0) + "/" + player.fuelTankSize    );

        ammo1Name.text = ( player.ammoSlot1.ammo.GetComponent<tankRound>().ammoName);
        ammo1Count.text = ("Ammo - "  + player.ammoSlot1.ammoCount.ToString());

        ammo2Name.text = (player.ammoSlot2.ammo.GetComponent<tankRound>().ammoName);
        ammo2Count.text = ("Ammo - " + player.ammoSlot2.ammoCount.ToString());


        ammo1Image.sprite = player.ammoSlot1.ammo.GetComponent<tankRound>().Icon;
        ammo2Image.sprite = player.ammoSlot2.ammo.GetComponent<tankRound>().Icon;

        if (player.loadedRoundChoice == 1)
        {
            ammo1Selected.text = ("Selected");
            ammo2Selected.text = ("");
        }
        if (player.loadedRoundChoice == 2)
        {
            ammo1Selected.text = ("");
            ammo2Selected.text = ("Selected");
        }


        if(player.loadedRound == null)
        {
            if(player.reloading == true)
            {
                ammoState.text = ("Reloading - " + System.Math.Round(player.reloadTemp, 1) + "S"     );
            }
            else
            {
                ammoState.text = ("None !! Reload (R)");
            }         
        }
        else
        {
            ammoState.text = (player.loadedRound.GetComponent<tankRound>().ammoName);
        }
    }
}
