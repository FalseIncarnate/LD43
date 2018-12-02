using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : Interactable_Object {

    internal bool showing_inventory = false;
    internal bool showing_favor = false;

    internal int cur_inv_category = 1;

    internal override void PreClose() {
        showing_inventory = false;
        gm.inv_menu_layout.SetActive(false);
        showing_favor = false;
        gm.favor_menu_layout.SetActive(false);
        gm.basic_menu_layout.SetActive(true);
    }

    internal override void UpdateMenu() {
        gm.SetText1("View Inventory");
        gm.SetText2("View Favor");
        gm.SetText3("");
        gm.SetText4("");
        gm.SetText5("");
        gm.SetText6("");
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                if(showing_inventory) {
                    PrevCategory();
                }else if(showing_favor) {
                    UpdateFavorMenu();
                } else {
                    //Inventory
                    OpenInventory();
                }
                break;
            case 2:
                if(showing_inventory) {
                    CloseInventory();
                } else if(showing_favor) {
                    CloseFavor();
                } else {
                    //Favor
                    OpenFavor();
                }
                break;
            case 3:
                if(showing_inventory) {
                    NextCategory();
                } else {
                    //Blank
                }
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

    void PrevCategory() {
        if(cur_inv_category == 1) {
            return;
        }
        cur_inv_category--;
        UpdateInventoryMenu();
    }

    void NextCategory() {
        if(cur_inv_category == 8) {
            return;
        }
        cur_inv_category++;
        UpdateInventoryMenu();
    }

    void UpdateInventoryMenu() {
        switch(cur_inv_category) {
            case 1:
                //Seeds
                gm.inv_category.text = "Seeds";
                gm.inv_list.text = "";
                foreach(InvEntry ie in inv.my_inv) {
                    if(ie.category == "Seeds") {
                        gm.inv_list.text += System.Environment.NewLine;
                        gm.inv_list.text += (ie.product_data + ": " + ie.product_owned);
                    }
                }
                break;
            case 2:
                //Produce
                gm.inv_category.text = "Produce";
                gm.inv_list.text = "";
                foreach(InvEntry ie in inv.my_inv) {
                    if(ie.category == "Produce") {
                        gm.inv_list.text += System.Environment.NewLine;
                        gm.inv_list.text += (ie.product_data + ": " + ie.product_owned);
                    }
                }
                break;
            case 3:
                //Animal
                gm.inv_category.text = "Animal Products";
                gm.inv_list.text = "";
                foreach(InvEntry ie in inv.my_inv) {
                    if(ie.category == "Animal") {
                        gm.inv_list.text += System.Environment.NewLine;
                        gm.inv_list.text += (ie.product_data + ": " + ie.product_owned);
                    }
                }
                break;
            case 4:
                //Food
                gm.inv_category.text = "Prepared Foods";
                gm.inv_list.text = "";
                foreach(InvEntry ie in inv.my_inv) {
                    if(ie.category == "Food") {
                        gm.inv_list.text += System.Environment.NewLine;
                        gm.inv_list.text += (ie.product_data + ": " + ie.product_owned);
                    }
                }
                break;
            case 5:
                //Drink
                gm.inv_category.text = "Drinks";
                gm.inv_list.text = "";
                foreach(InvEntry ie in inv.my_inv) {
                    if(ie.category == "Drinks") {
                        gm.inv_list.text += System.Environment.NewLine;
                        gm.inv_list.text += (ie.product_data + ": " + ie.product_owned);
                    }
                }
                break;
            case 6:
                //Crafts
                gm.inv_category.text = "Crafts";
                gm.inv_list.text = "";
                foreach(InvEntry ie in inv.my_inv) {
                    if(ie.category == "Crafts") {
                        gm.inv_list.text += System.Environment.NewLine;
                        gm.inv_list.text += (ie.product_data + ": " + ie.product_owned);
                    }
                }
                break;
            case 7:
                //Resources
                gm.inv_category.text = "Resources";
                gm.inv_list.text = "";
                foreach(InvEntry ie in inv.my_inv) {
                    if(ie.category == "Resource") {
                        gm.inv_list.text += System.Environment.NewLine;
                        gm.inv_list.text += (ie.product_data + ": " + ie.product_owned);
                    }
                }
                break;
            case 8:
                //Special
                gm.inv_category.text = "Special";
                gm.inv_list.text = "";
                gm.inv_list.text += ("Fishing Rod Owned: " + inv.has_fishing_rod);
                gm.inv_list.text += System.Environment.NewLine;
                gm.inv_list.text += ("Pickaxe Owned: " + inv.has_pickaxe);
                break;
        }
    }

    void OpenInventory() {
        gm.basic_menu_layout.SetActive(false);
        gm.inv_menu_layout.SetActive(true);
        UpdateInventoryMenu();
        showing_inventory = true;
    }

    void CloseInventory() {
        gm.inv_menu_layout.SetActive(false);
        gm.basic_menu_layout.SetActive(true);
        showing_inventory = false;
    }

    void UpdateFavorMenu() {
        gm.favor_list.text = "";
        gm.favor_list.text += ("Produce Spirit's Favor: " + gm.produce_spirit_favor);
        gm.favor_list.text += System.Environment.NewLine;
        gm.favor_list.text += ("Flesh Spirit's Favor: " + gm.flesh_spirit_favor);
        gm.favor_list.text += System.Environment.NewLine;
        gm.favor_list.text += ("Blood Spirit's Favor: " + gm.blood_spirit_favor);
        gm.favor_list.text += System.Environment.NewLine;
        gm.favor_list.text += ("Food Spirit's Favor: " + gm.food_spirit_favor);
        gm.favor_list.text += System.Environment.NewLine;
        gm.favor_list.text += ("Drink Spirit's Favor: " + gm.drink_spirit_favor);
        gm.favor_list.text += System.Environment.NewLine;
        gm.favor_list.text += ("Craft Spirit's Favor: " + gm.craft_spirit_favor);

    }

    void OpenFavor() {
        gm.basic_menu_layout.SetActive(false);
        gm.favor_menu_layout.SetActive(true);
        UpdateFavorMenu();
        showing_favor = true;
    }

    void CloseFavor() {
        gm.favor_menu_layout.SetActive(false);
        gm.basic_menu_layout.SetActive(true);
        showing_favor = false;
    }
}
