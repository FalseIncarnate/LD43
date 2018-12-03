using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalMine : Interactable_Object {

    internal Product coal = new Coal();

    // Use this for initialization
    void Start() {
        object_name = "Coal Mine";
        requires_pickaxe = true;
    }

    internal override void UpdateMenu() {
        gm.SetText1("Mine Coal (requires pickaxe)");
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
                //Mine Coal (requires pickaxe)
                if(inv.has_pickaxe) {
                    MineCoal();
                }
                MineCoal();
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

    internal void MineCoal() {
        StartActivity("Mining Coal");
    }

    internal override void ActivityFinish() {
        base.ActivityFinish();
        inv.UpdateItemCount(coal, 1);
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
            inv.UpdateItemCount(coal, 1);
        }
    }
}
