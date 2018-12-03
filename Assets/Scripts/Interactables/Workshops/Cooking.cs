using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : Workshop
{
    // Use this for initialization
    void Start() {
        object_name = "Kitchen";
    }

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        can_upgrade = true;
        max_upgrade_level = 1;

        upgrade_list.Add(new CookingUpgrade1());

        upgrade_recipe = upgrade_list[0];
    }

    internal override void SetupRecipes() {
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new FlourRecipe(), tier_needed = 0 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new BeefMeatPackageRecipe(), tier_needed = 0 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new ChickenMeatPackageRecipe(), tier_needed = 0 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new FishMeatPackageRecipe(), tier_needed = 0 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new BreadRecipe(), tier_needed = 1 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new CheeseRecipe(), tier_needed = 1 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new JamRecipe(), tier_needed = 1 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new CakeRecipe(), tier_needed = 1 });
    }

    internal override void MenuPage1() {
        option1 = "Make Flour" + GenRecipeReqString(workshop_recipes[0].recipe);
        option2 = "Package Beef" + GenRecipeReqString(workshop_recipes[1].recipe);
        option3 = "Package Chicken" + GenRecipeReqString(workshop_recipes[2].recipe);
        option4 = "Package Fish" + GenRecipeReqString(workshop_recipes[3].recipe); ;
        option5 = "Upgrade required";
        if(upgrade_level == 1) {
            option5 = "Bake Bread" + GenRecipeReqString(workshop_recipes[4].recipe);
        }
        option6 = "Next Page";
    }
    internal override void MenuPage2() {
        option1 = "Prev Page";
        option2 = "Upgrade required";
        option3 = "Upgrade required";
        option4 = "Upgrade required";
        if(upgrade_level >= 1) {
            option2 = "Make Cheese" + GenRecipeReqString(workshop_recipes[5].recipe);
            option3 = "Make Jam" + GenRecipeReqString(workshop_recipes[6].recipe);
            option4 = "Bake Cake" + GenRecipeReqString(workshop_recipes[7].recipe);
        }
        option5 = "";
        option6 = "Upgrade " + GenUpgradeReqString(upgrade_recipe);
    }

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
                    //Blank
                }
                break;
            case 6:
                if(menu_page == 1) {
                    //Next Page
                    menu_page = 2;
                    UpdateMenu();
                } else {
                    //Upgrade
                    AttemptUpgrade();
                }
                break;
        }
    }
}
