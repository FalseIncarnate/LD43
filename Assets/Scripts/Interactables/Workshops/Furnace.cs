using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : Workshop {

    internal CraftRecipe wood_fuel = new WoodFuelRecipe();
    internal CraftRecipe coal_fuel = new CoalFuelRecipe();
    
    // Use this for initialization
    void Start () {
        object_name = "Furnace";
	}

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        can_upgrade = true;
        max_upgrade_level = 2;

        upgrade_list.Add(new FurnaceUpgrade1());
        upgrade_list.Add(new FurnaceUpgrade2());

        upgrade_recipe = upgrade_list[0];
    }

    internal override void SetupRecipes() {
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new GlasswareRecipe(), tier_needed = 1 });
        workshop_recipes.Add(new WorkshopRecipe() { recipe = new MetalBarsRecipe(), tier_needed = 2 });
    }

    internal override void MenuPage1() {
        option1 = "Upgrade required";
        option2 = "Upgrade required";
        option3 = "Upgrade required";
        option4 = "Upgrade required";
        option5 = "Upgrade required";
        if(upgrade_level >= 1) {
            option1 = "Add Fuel (requires 1 wood) [Current Fuel: " + fuel_level + "]";
            option2 = "Add Fuel (requires 1 coal) [Current Fuel: " + fuel_level + "]";
            option3 = "Make Glass [uses fuel]";
            option4 = "Make Glassware " + GenRecipeReqString(workshop_recipes[0].recipe) + " [uses fuel] ";
        }
        if(upgrade_level == 2) {
            option5 = "Make Metal Bars " + GenRecipeReqString(workshop_recipes[1].recipe) + " [uses fuel]";
        }
        option6 = "Upgrade" + GenUpgradeReqString(upgrade_recipe);
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                //Add Fuel (wood)
                AddFuel();
                UpdateMenu();
                break;
            case 2:
                //Add Fuel (coal)
                AddFuel(true);
                UpdateMenu();
                break;
            case 3:
                //Make Glass
                MakeGlass();
                break;
            case 4:
                //Make Glassware
                AttemptCraft(1);
                break;
            case 5:
                //Make Metal Bars
                AttemptCraft(2);
                break;
            case 6:
                //Upgrade
                AttemptUpgrade();
                break;
        }
    }

    internal void AddFuel(bool is_coal = false) {
        if(upgrade_level < 1) {
            return;
        }
        if(fuel_level >= MAX_FUEL) {
            return;
        }
        if(is_coal) {
            if(coal_fuel.CheckRequirements(inv)) {
                coal_fuel.ConsumeCost(inv);
                fuel_level += 40;
            }
        } else {
            if(wood_fuel.CheckRequirements(inv)) {
                wood_fuel.ConsumeCost(inv);
                fuel_level += 5;
            }
        }
    }

    internal override void AttemptCraft(int recipe_num) {
        if(fuel_level == 0) {
            return;
        }
        base.AttemptCraft(recipe_num);
    }

    internal void MakeGlass() {
        if(fuel_level == 0 || upgrade_level < 1) {
            return;
        }
        to_make = null;
        StartActivity("Making Glass");
    }

    internal override void ActivityFinish() {
        base.ActivityFinish();
        fuel_level--;
        if(to_make == null) {
            inv.UpdateItemCount(new Glass(), 1);
        }
    }
}
