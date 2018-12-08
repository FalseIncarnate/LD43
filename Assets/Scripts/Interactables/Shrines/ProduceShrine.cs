using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceShrine : Shrine {

	// Use this for initialization
	void Start () {
		object_name = "Produce Shrine";
        patron = "Produce";
	}

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        upgrade_list.Add(new ProduceShrineUpgrade1());
        upgrade_list.Add(new ProduceShrineUpgrade2());
        upgrade_list.Add(new ProduceShrineUpgrade3());
        upgrade_list.Add(new ProduceShrineUpgrade4());

        upgrade_recipe = upgrade_list[0];
    }

    internal override void SetupSacrifices() {
        accepted_sacrifices.Add(new Berry());
        accepted_sacrifices.Add(new Corn());
        accepted_sacrifices.Add(new Cotton());
        accepted_sacrifices.Add(new Grain());
    }

    internal override void MenuPage1() {
        option1 = "Offer Berries";
        option2 = "Offer Corn";
        option3 = "Offer Cotton";
        option4 = "Offer Grain";
        option5 = "";
        option6 = "Upgrade" + GenUpgradeReqString(upgrade_recipe);
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                //Offer Berries
                AttemptSacrifice(1);
                break;
            case 2:
                //Offer Corn
                AttemptSacrifice(2);
                break;
            case 3:
                //Offer Cotton
                AttemptSacrifice(3);
                break;
            case 4:
                //Offer Grain
                AttemptSacrifice(4);
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
        return offering.produce_value;
    }
}
