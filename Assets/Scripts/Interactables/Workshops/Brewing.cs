using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brewing : Workshop {

    // Use this for initialization
    void Start() {
        object_name = "Brewery";
    }

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        can_upgrade = true;
        max_upgrade_level = 4;

        upgrade_list.Add(new BrewingUpgrade1());
        upgrade_list.Add(new BrewingUpgrade2());
        upgrade_list.Add(new BrewingUpgrade3());
        upgrade_list.Add(new BrewingUpgrade4());

        upgrade_recipe = upgrade_list[0];
    }

    internal override void SetupRecipes() {
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new JuiceRecipe(), tier_needed = 1 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new BeerRecipe(), tier_needed = 2 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new WineRecipe(), tier_needed = 3 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new MeadRecipe(), tier_needed = 4 });
    }

    internal override void MenuPage1() {
        option1 = "Upgrade required";
        option2 = "Upgrade required";
        option3 = "Upgrade required";
        option4 = "Upgrade required";
        if(upgrade_level >= 1) {
            option1 = "Make Juice" + GenRecipeReqString(workshop_recipes[0].recipe);
        }
        if(upgrade_level >= 2) {
            option2 = "Brew Beer" + GenRecipeReqString(workshop_recipes[1].recipe);
        }
        if(upgrade_level >= 3) {
            option3 = "Make Wine" + GenRecipeReqString(workshop_recipes[0].recipe);
        }
        if(upgrade_level == 4) {
            option4 = "Make Mead" + GenRecipeReqString(workshop_recipes[0].recipe);
        }
        option5 = "";
        option6 = "Upgrade " + GenUpgradeReqString(upgrade_recipe);
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                //Make Juice
                AttemptCraft(1);
                break;
            case 2:
                //Brew Beer
                AttemptCraft(2);
                break;
            case 3:
                //Make Wine
                AttemptCraft(3);
                break;
            case 4:
                //Make Mead
                AttemptCraft(4);
                break;
            case 5:
                //Blank
                break;
            case 6:
                //Upgrade
                AttemptUpgrade();
                break;
        }
    }
}
