using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taxman : Interactable_Object {

	// Use this for initialization
	void Start () {
        object_name = "The Taxman";
	}

    internal override bool AttemptInteract() {
        if(!gm.taxes_active) {
            return false;
        }
        return gm.taxes_paid;
    }

    internal override void UpdateMenu() {
        gm.ClearAllText();
        if(gm.taxes_active && !gm.taxes_paid) {
            gm.SetText1("Pay Taxes: $" + gm.taxes_due);
        } else {
            gm.SetText1("Taxes Paid!");
        }
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                //Pay Taxes
                AttemptTaxPayment();
                break;
            case 2:
                //thing
                break;
            case 3:
                //thing
                break;
            case 4:
                //thing
                break;
            case 5:
                //thing
                break;
            case 6:
                //thing
                break;
        }
    }

    internal void AttemptTaxPayment() {
        if(!gm.taxes_active) {
            gm.taxes_paid = true;
            return;
        }
        if(inv.money < gm.taxes_due) {
            return;
        }
        if(gm.taxes_paid) {
            return;
        }
        inv.UpdateMoney(gm.taxes_due * -1);
        gm.taxes_paid = true;
        gm.player.CloseMenu();
    }
}
