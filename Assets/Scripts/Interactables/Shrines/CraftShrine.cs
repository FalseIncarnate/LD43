using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftShrine : Shrine {

    // Use this for initialization
    void Start() {
        object_name = "Craft Shrine";
        patron = "Craft";
    }

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        upgrade_list.Add(new CraftShrineUpgrade1());
        upgrade_list.Add(new CraftShrineUpgrade2());
        upgrade_list.Add(new CraftShrineUpgrade3());
        upgrade_list.Add(new CraftShrineUpgrade4());

        upgrade_recipe = upgrade_list[0];
    }

    internal override void SetupSacrifices() {
        accepted_sacrifices.Add(new Candles());
        accepted_sacrifices.Add(new ClothBolts());
        accepted_sacrifices.Add(new ClothGoods());
        accepted_sacrifices.Add(new Shoes());
        accepted_sacrifices.Add(new Tools());
        accepted_sacrifices.Add(new Glassware());
        accepted_sacrifices.Add(new Furniture());
        accepted_sacrifices.Add(new Decorations());
    }

    internal override void MenuPage1() {
        option1 = "Offer Candles";
        option2 = "Offer Cloth Bolts";
        option3 = "Offer Cloth Goods";
        option4 = "Offer Shoes";
        option5 = "Offer Tools";
        option6 = "Next Page";
    }

    internal override void MenuPage2() {
        option1 = "Prev Page";
        option2 = "Offer Glassware";
        option3 = "Offer Furniture";
        option4 = "Offer Decorations";
        option5 = "";
        option6 = "Upgrade";
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                if(menu_page == 1) {
                    //Offer Candles
                    AttemptSacrifice(1);
                } else {
                    //Prev Page
                    menu_page--;
                    UpdateMenu();
                }
                break;
            case 2:
                if(menu_page == 1) {
                    //Offer Cloth Bolts
                    AttemptSacrifice(2);
                } else {
                    //Offer Glassware
                    AttemptSacrifice(6);
                }
                break;
            case 3:
                if(menu_page == 1) {
                    //Offer Cloth Goods
                    AttemptSacrifice(3);
                } else {
                    //Offer Furniture
                    AttemptSacrifice(7);
                }
                break;
            case 4:
                if(menu_page == 1) {
                    //Offer Shoes
                    AttemptSacrifice(4);
                } else {
                    //Offer Decorations
                    AttemptSacrifice(8);
                }
                break;
            case 5:
                if(menu_page == 1) {
                    //Offer Tools
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
        return offering.craft_value;
    }
}
