using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : Interactable_Object {

    internal string patron = "";

    internal string option1 = "";
    internal string option2 = "";
    internal string option3 = "";
    internal string option4 = "";
    internal string option5 = "";
    internal string option6 = "";
    internal int menu_page = 1;

    internal List<Product> accepted_sacrifices = new List<Product>();

	// Use this for initialization
	void Start () {
        object_name = "Shrine";
	}

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        can_upgrade = true;
        max_upgrade_level = 4;
    }

    internal override void SetupSacrifices() {

    }

    internal override void OnUpgrade() {
        base.OnUpgrade();
        gm.UpgradeFavor(patron);
    }

    internal override void Tantrum() {
        upgrade_level--;
        base.Tantrum();
    }

    internal void Sacrifice(Product offering) {
        if(offering == null) {
            return;
        }
        if(gm.CheckSpiritMaxed(patron)) {
            return;
        }
        if(!inv.HaveItem(offering)) {
            return;
        }
        int sacrifice_value = GetSacrificeValue(offering);
        inv.UpdateItemCount(offering, -1);
        gm.UpdateFavor(patron, sacrifice_value);
        gm.player.CloseMenu();
    }

    internal virtual int GetSacrificeValue(Product offering) {
        return 0;
    }

    internal override bool AttemptInteract() {
        return true;
    }

    internal override void UpdateMenu() {
        if(menu_page == 1) {
            MenuPage1();
        } else {
            MenuPage2();
        }
        gm.SetText1(option1);
        gm.SetText2(option2);
        gm.SetText3(option3);
        gm.SetText4(option4);
        gm.SetText5(option5);
        gm.SetText6(option6);
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                if(menu_page == 1) {
                    //Recipe 1
                    AttemptSacrifice(1);
                } else {
                    //Prev Page
                    menu_page--;
                    UpdateMenu();
                }
                break;
            case 2:
                if(menu_page == 1) {
                    //Recipe 2
                    AttemptSacrifice(2);
                } else if(menu_page == 2) {
                    //Recipe 6
                    AttemptSacrifice(6);
                } else {
                    
                }
                break;
            case 3:
                if(menu_page == 1) {
                    //Recipe 3
                    AttemptSacrifice(3);
                } else if(menu_page == 2) {
                    //Recipe 7
                    AttemptSacrifice(7);
                } else {
                    
                }
                break;
            case 4:
                if(menu_page == 1) {
                    //Recipe 4
                    AttemptSacrifice(4);
                } else if(menu_page == 2) {
                    //Recipe 8
                    AttemptSacrifice(8);
                } else {
                    
                }
                break;
            case 5:
                if(menu_page == 1) {
                    //Recipe 5
                    AttemptSacrifice(5);
                } else if(menu_page == 2) {
                    //Recipe 9
                    AttemptSacrifice(9);
                } else {
                    
                }
                break;
            case 6:
                if(menu_page <= 2) {
                    //Next Page
                    menu_page++;
                    UpdateMenu();
                } else {
                    //Upgrade
                    AttemptUpgrade();
                }
                break;
        }
    }

    internal virtual void MenuPage1() {
        option1 = "Offer 1";
        option2 = "Offer 2";
        option3 = "Offer 3";
        option4 = "Offer 4";
        option5 = "Offer 5";
        option6 = "Next Page";
    }

    internal virtual void MenuPage2() {
        option1 = "Prev Page";
        option2 = "Offer 6";
        option3 = "Offer 7";
        option4 = "Offer 8";
        option5 = "Offer 9";
        option6 = "Next Page";
    }

    internal virtual void MenuPage3() {
        option1 = "Prev Page";
        option2 = "Offer 10";
        option3 = "Offer 11";
        option4 = "Offer 12";
        option5 = "Offer 13";
        option6 = "Upgrade";
    }

    internal void AttemptSacrifice(int offering_num) {
        if(gm.CheckSpiritMaxed(patron)) {
            return;
        }
        Product offering = accepted_sacrifices[offering_num - 1];
        Sacrifice(offering);
    }

}
