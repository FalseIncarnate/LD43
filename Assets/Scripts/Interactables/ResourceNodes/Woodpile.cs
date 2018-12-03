using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woodpile : Interactable_Object {

    internal Product wood = new Wood();

	// Use this for initialization
	void Start () {
        object_name = "Woodpile";
	}

    internal override void UpdateMenu() {
        gm.SetText1("Gather Wood");
        gm.SetText2("");
        gm.SetText3("");
        gm.SetText4("");
        gm.SetText5("");
        gm.SetText6("");
    }

    internal override bool AttemptInteract() {
        return true;
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                //Gather Wood
                GatherWood();
                break;
            case 2:
                //Blank
                break;
            case 3:
                //Blank
                break;
            case 4:
                //Blank
                break;
            case 5:
                //Blank
                break;
            case 6:
                //Blank
                break;
        }
    }

    internal void GatherWood() {
        StartActivity("Gathering Wood");
    }

    internal override void ActivityFinish() {
        base.ActivityFinish();
        inv.UpdateItemCount(wood, 1);
        CheckSpiritFavorBonus();
    }

    internal void CheckSpiritFavorBonus() {
        int craft_favor = gm.craft_spirit_favor;
        int blood_favor = gm.blood_spirit_favor;

        int spirit_bonus = 0;
        
        if(craft_favor >= 400) {
            spirit_bonus += 15;
        } else if(craft_favor <= 100) {
            spirit_bonus -= 15;
        }

        if(blood_favor >= 400) {
            spirit_bonus += 10;
        } else if(blood_favor <= 100) {
            spirit_bonus -= 10;
        }

        if(spirit_bonus <= 0) {
            return;
        }

        //high favor can double gathering
        if(spirit_bonus >= (int)Random.Range(0, 100)) {
            inv.UpdateItemCount(wood, 1);
        }
    }
}
