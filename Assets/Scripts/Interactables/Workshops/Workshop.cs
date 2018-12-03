using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workshop : Interactable_Object {

    internal List<WorkshopRecipe> workshop_recipes = new List<WorkshopRecipe>();

    internal string option1 = "";
    internal string option2 = "";
    internal string option3 = "";
    internal string option4 = "";
    internal string option5 = "";
    internal string option6 = "";

    internal int menu_page = 1;
    internal CraftRecipe to_make;

    // Use this for initialization
    void Start () {
        object_name = "Workshop";
	}

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        can_upgrade = true;
        max_upgrade_level = 4;
    }

    internal override void SetupRecipes() {

    }

    internal virtual void MenuPage1() {
        option1 = "Recipe 1";
        option2 = "Recipe 2";
        option3 = "Recipe 3";
        option4 = "Recipe 4";
        option5 = "Recipe 5";
        option6 = "Next Page";
    }

    internal virtual void MenuPage2() {
        option1 = "Prev Page";
        option2 = "Recipe 6";
        option3 = "Recipe 7";
        option4 = "Recipe 8";
        option5 = "Recipe 9";
        option6 = "Upgrade";
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

    internal override bool AttemptInteract() {
        return true;
    }

    /* Quick Reference
    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                if(menu_page == 1) {
                    //Recipe 1
                    AttemptCraft(1);
                } else {
                    //Prev Page
                    menu_page = 1;
                    UpdateMenu();
                }
                break;
            case 2:
                if(menu_page == 1) {
                    //Recipe 2
                    AttemptCraft(2);
                } else {
                    //Recipe 6
                    AttemptCraft(6);
                }
                break;
            case 3:
                if(menu_page == 1) {
                    //Recipe 3
                    AttemptCraft(3);
                } else {
                    //Recipe 7
                    AttemptCraft(7);
                }
                break;
            case 4:
                if(menu_page == 1) {
                    //Recipe 4
                    AttemptCraft(4);
                } else {
                    //Recipe 8
                    AttemptCraft(8);
                }
                break;
            case 5:
                if(menu_page == 1) {
                    //Recipe 5
                    AttemptCraft(5);
                } else {
                    //Recipe 9
                    AttemptCraft(9);
                }
                break;
            case 6:
                if(menu_page == 1) {
                    //Next Page
                    menu_page = 2;
                    UpdateMenu();
                } else {
                    //Upgrade
                }
                break;
        }
    }
    */

    internal virtual void AttemptCraft(int recipe_num) {
        WorkshopRecipe recipe_to_check = workshop_recipes[recipe_num - 1];
        if(recipe_to_check.tier_needed > upgrade_level) {
            return;
        }
        to_make = recipe_to_check.recipe;
        if(to_make.CheckRequirements(inv)) {
            StartActivity("Crafting " + to_make.product.product_name);
        }
    }

    internal override void ActivityFinish() {
        base.ActivityFinish();
        if(to_make != null) {
            to_make.CreateResult(inv);
        }
    }
}

public class WorkshopRecipe
{
    public CraftRecipe recipe { get; set; }
    public int tier_needed { get; set; }
}
