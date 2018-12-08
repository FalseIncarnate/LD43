using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShrine : Shrine {

    // Use this for initialization
    void Start() {
        object_name = "Food Shrine";
        patron = "Food";
    }

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        upgrade_list.Add(new FoodShrineUpgrade1());
        upgrade_list.Add(new FoodShrineUpgrade2());
        upgrade_list.Add(new FoodShrineUpgrade3());
        upgrade_list.Add(new FoodShrineUpgrade4());

        upgrade_recipe = upgrade_list[0];
    }

    internal override void SetupSacrifices() {
        accepted_sacrifices.Add(new Flour());
        accepted_sacrifices.Add(new Eggs());
        accepted_sacrifices.Add(new MeatPackages());
        accepted_sacrifices.Add(new Bread());
        accepted_sacrifices.Add(new Cheese());
        accepted_sacrifices.Add(new Jam());
        accepted_sacrifices.Add(new Honey());
        accepted_sacrifices.Add(new Cake());
    }

    internal override void MenuPage1() {
        option1 = "Offer Flour";
        option2 = "Offer Eggs";
        option3 = "Offer Packaged Meat";
        option4 = "Offer Bread";
        option5 = "Offer Cheese";
        option6 = "Next Page";
    }

    internal override void MenuPage2() {
        option1 = "Prev Page";
        option2 = "Offer Jam";
        option3 = "Offer Honey";
        option4 = "Offer Cake";
        option5 = "";
        option6 = "Upgrade" + GenUpgradeReqString(upgrade_recipe);
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                if(menu_page == 1) {
                    //Offer Flour
                    AttemptSacrifice(1);
                } else {
                    //Prev Page
                    menu_page--;
                    UpdateMenu();
                }
                break;
            case 2:
                if(menu_page == 1) {
                    //Offer Eggs
                    AttemptSacrifice(2);
                } else {
                    //Offer Jam
                    AttemptSacrifice(6);
                }
                break;
            case 3:
                if(menu_page == 1) {
                    //Offer Packaged Meat
                    AttemptSacrifice(3);
                } else {
                    //Offer Honey
                    AttemptSacrifice(7);
                }
                break;
            case 4:
                if(menu_page == 1) {
                    //Offer Bread
                    AttemptSacrifice(4);
                } else {
                    //Offer Cake
                    AttemptSacrifice(8);
                }
                break;
            case 5:
                if(menu_page == 1) {
                    //Offer Cheese
                    AttemptSacrifice(5);
                } else {
                    //Blank
                }
                break;
            case 6:
                if(menu_page == 1) {
                    //Next Page
                    menu_page++;
                    UpdateMenu();
                } else {
                    AttemptUpgrade();
                }
                break;
        }
    }

    internal override int GetSacrificeValue(Product offering) {
        return offering.food_value;
    }
}
