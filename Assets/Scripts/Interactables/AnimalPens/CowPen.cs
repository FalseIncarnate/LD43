using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowPen : AnimalPen {

    internal Product beef = new Beef();
    internal Product leather = new Leather();

    internal CraftRecipe milk_recipe = new MilkRecipe();

	// Use this for initialization
	void Start () {
        object_name = "Cow Pasture";
        requires_feed = true;
        feed_product = new Grain();
        max_mature_animals = 2;
        maturity_rate = 20;
        StartCoroutine(MatureDelay(maturity_rate));
    }

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        
        upgrade_list.Add(new CowUpgrade1());
        upgrade_list.Add(new CowUpgrade2());
        upgrade_list.Add(new CowUpgrade3());
        upgrade_list.Add(new CowUpgrade4());

        upgrade_recipe = upgrade_list[0];
    }

    internal override void OnUpgrade() {
        base.OnUpgrade();
        switch(upgrade_level) {
            case 0:
                max_mature_animals = 2;
                maturity_rate = 20;
                break;
            case 1:
                max_mature_animals = 4;
                maturity_rate = 20;
                break;
            case 2:
                max_mature_animals = 6;
                maturity_rate = 15;
                break;
            case 3:
                max_mature_animals = 8;
                maturity_rate = 15;
                break;
            case 4:
                max_mature_animals = 10;
                maturity_rate = 10;
                break;
        }
    }

    internal override void UpdateMenu() {
        gm.SetText1("Butcher Cow");
        gm.SetText2("Get Milk" + GenRecipeReqString(milk_recipe));
        gm.SetText3("Feed" + System.Environment.NewLine + "(requires 1 Grain)");
        gm.SetText4("");
        gm.SetText5("Upgrade " + GenUpgradeReqString(upgrade_recipe));
        gm.SetText6("");
    }

    internal override bool AttemptInteract() {
        return true;
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                //Butcher Cow
                gm.player.CloseMenu();
                if(mature_animals > 0) {
                    ButcherAnimal();
                }
                break;
            case 2:
                //Get Milk (requires 1 Empty Bucket)
                GetMilk();
                break;
            case 3:
                //Feed (requires 1 Grain);
                FeedPen();
                break;
            case 4:
                //Blank
                break;
            case 5:
                //Upgrade
                AttemptUpgrade();
                break;
            case 6:
                //Blank
                break;
        }
    }

    internal void GetMilk() {
        if(milk_recipe.CheckRequirements(inv)) {
            StartActivity("Milking Cows");
        }
    }

    internal override void ActivityFinish() {
        base.ActivityFinish();
        milk_recipe.CreateResult(inv);
    }

    internal override void ButcherAnimal(bool meddle = false) {
        base.ButcherAnimal();
        if(meddle) {
            return;
        }
        inv.UpdateItemCount(beef, 1);
        inv.UpdateItemCount(blood, 1);
        if(50 >= (int)Random.Range(0, 100)) {
            inv.UpdateItemCount(leather, 1);
        }
    }
}
