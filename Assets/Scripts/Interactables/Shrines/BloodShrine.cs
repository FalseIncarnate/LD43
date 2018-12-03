using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodShrine : Shrine {

    // Use this for initialization
    void Start() {
        object_name = "Blood Shrine";
        patron = "Blood";
    }

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        upgrade_list.Add(new BloodShrineUpgrade1());
        upgrade_list.Add(new BloodShrineUpgrade2());
        upgrade_list.Add(new BloodShrineUpgrade3());
        upgrade_list.Add(new BloodShrineUpgrade4());

        upgrade_recipe = upgrade_list[0];
    }

    internal override void SetupSacrifices() {
        accepted_sacrifices.Add(new Blood());
    }

    internal override void MenuPage1() {
        option1 = "Offer Blood";
        option2 = "";
        option3 = "";
        option4 = "";
        option5 = "";
        option6 = "Upgrade";
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                //Offer Blood
                AttemptSacrifice(1);
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
                AttemptUpgrade();
                break;
        }
    }

    internal override int GetSacrificeValue(Product offering) {
        return offering.blood_value;
    }
}
