using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : Workshop {

    // Use this for initialization
    void Start() {
        object_name = "Crafting Station";
    }

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        can_upgrade = true;
        max_upgrade_level = 3;

        upgrade_list.Add(new CraftingUpgrade1());
        upgrade_list.Add(new CraftingUpgrade2());
        upgrade_list.Add(new CraftingUpgrade3());

        upgrade_recipe = upgrade_list[0];
    }

    internal override void SetupRecipes() {
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new EmptyBucketRecipe(), tier_needed = 0 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new CandleRecipe(), tier_needed = 0 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new ClothBoltsRecipe(), tier_needed = 1 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new ClothGoodsRecipe(), tier_needed = 1 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new ShoesRecipe(), tier_needed = 2 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new FurnitureRecipe(), tier_needed = 2 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new ToolsRecipe(), tier_needed = 2 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new BarrelsRecipe(), tier_needed = 3 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new DecorationsRecipe(), tier_needed = 3 });
    }

    internal override void MenuPage1() {
        option1 = "Make Buckets" + GenRecipeReqString(workshop_recipes[0].recipe);
        option2 = "Make Candles" + GenRecipeReqString(workshop_recipes[1].recipe);
        option3 = "Upgrade required";
        option4 = "Upgrade required";
        option5 = "Upgrade required";
        if(upgrade_level >= 1) {
            option3 = "Weave Cloth" + GenRecipeReqString(workshop_recipes[2].recipe);
            option4 = "Make Cloth Goods" + GenRecipeReqString(workshop_recipes[3].recipe);
        }
        if(upgrade_level >= 2) {
            option5 = "Make Shoes" + GenRecipeReqString(workshop_recipes[4].recipe);
        }
        option6 = "Next Page";
    }
    internal override void MenuPage2() {
        option1 = "Prev Page";
        option2 = "Upgrade required";
        option3 = "Upgrade required";
        option4 = "Upgrade required";
        option5 = "Upgrade required";
        if(upgrade_level >= 2) {
            option2 = "Build Furniture" + GenRecipeReqString(workshop_recipes[5].recipe);
            option3 = "Make Tools" + GenRecipeReqString(workshop_recipes[6].recipe);
        }
        if(upgrade_level == 3) {
            option4 = "Make Barrels" + GenRecipeReqString(workshop_recipes[7].recipe);
            option4 = "Make Decorations" + GenRecipeReqString(workshop_recipes[8].recipe);
        }
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
                    AttemptUpgrade();
                }
                break;
        }
    }
}
