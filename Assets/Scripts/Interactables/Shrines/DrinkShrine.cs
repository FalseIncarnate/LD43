using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkShrine : Shrine {

    // Use this for initialization
    void Start() {
        object_name = "Drink Shrine";
        patron = "Drink";
    }

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        upgrade_list.Add(new DrinkShrineUpgrade1());
        upgrade_list.Add(new DrinkShrineUpgrade2());
        upgrade_list.Add(new DrinkShrineUpgrade3());
        upgrade_list.Add(new DrinkShrineUpgrade4());

        upgrade_recipe = upgrade_list[0];
    }

    internal override void SetupSacrifices() {
        accepted_sacrifices.Add(new Milk());
        accepted_sacrifices.Add(new Juice());
        accepted_sacrifices.Add(new Beer());
        accepted_sacrifices.Add(new Wine());
        accepted_sacrifices.Add(new Mead());
    }

    internal override void MenuPage1() {
        option1 = "Offer Milk";
        option2 = "Offer Juice";
        option3 = "Offer Beer";
        option4 = "Offer Wine";
        option5 = "Offer Mead";
        option6 = "Upgrade";
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                //Offer Milk
                AttemptSacrifice(1);
                break;
            case 2:
                //Offer Juice
                AttemptSacrifice(2);
                break;
            case 3:
                //Offer Beer
                AttemptSacrifice(3);
                break;
            case 4:
                //Offer Wine
                AttemptSacrifice(4);
                break;
            case 5:
                //Offer Mead
                AttemptSacrifice(5);
                break;
            case 6:
                AttemptUpgrade();
                break;
        }
    }

    internal override int GetSacrificeValue(Product offering) {
        return offering.drink_value;
    }
}
