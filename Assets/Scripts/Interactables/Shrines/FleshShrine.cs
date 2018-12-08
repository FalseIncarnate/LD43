using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleshShrine : Shrine {

    // Use this for initialization
    void Start() {
        object_name = "Flesh Shrine";
        patron = "Flesh";
    }

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        upgrade_list.Add(new FleshShrineUpgrade1());
        upgrade_list.Add(new FleshShrineUpgrade2());
        upgrade_list.Add(new FleshShrineUpgrade3());
        upgrade_list.Add(new FleshShrineUpgrade4());

        upgrade_recipe = upgrade_list[0];
    }

    internal override void SetupSacrifices() {
        accepted_sacrifices.Add(new Beef());
        accepted_sacrifices.Add(new ChickenMeat());
        accepted_sacrifices.Add(new Fish());
        accepted_sacrifices.Add(new Leather());
    }

    internal override void MenuPage1() {
        option1 = "Offer Beef";
        option2 = "Offer Chicken Meat";
        option3 = "Offer Fish";
        option4 = "Offer Leather";
        option5 = "";
        option6 = "Upgrade" + GenUpgradeReqString(upgrade_recipe);
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                //Offer Beef
                AttemptSacrifice(1);
                break;
            case 2:
                //Offer Chicken Meat
                AttemptSacrifice(2);
                break;
            case 3:
                //Offer Fish
                AttemptSacrifice(3);
                break;
            case 4:
                //Offer Leather
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
        return offering.flesh_value;
    }
}
