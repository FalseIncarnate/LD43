using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPen : AnimalPen {

    internal CraftRecipe fill_bucket_recipe = new FillBucketRecipe();
    internal Product fish = new Fish();

	// Use this for initialization
	void Start () {
        object_name = "Fish Pond";
        requires_feed = false;
        requires_fishing_rod = true;
        max_mature_animals = 5;
        maturity_rate = 5;
        StartCoroutine(MatureDelay(maturity_rate));
    }

    internal override void SetupUpgrades() {
        base.SetupUpgrades();

        upgrade_list.Add(new FishUpgrade1());
        upgrade_list.Add(new FishUpgrade2());
        upgrade_list.Add(new FishUpgrade3());
        upgrade_list.Add(new FishUpgrade4());

        upgrade_recipe = upgrade_list[0];
    }

    internal override void OnUpgrade() {
        base.OnUpgrade();
        switch(upgrade_level) {
            case 0:
                max_mature_animals = 5;
                maturity_rate = 5;
                break;
            case 1:
                max_mature_animals = 10;
                maturity_rate = 5;
                break;
            case 2:
                max_mature_animals = 15;
                maturity_rate = 4;
                break;
            case 3:
                max_mature_animals = 20;
                maturity_rate = 4;
                break;
            case 4:
                max_mature_animals = 25;
                maturity_rate = 3;
                break;
        }
    }

    internal override void UpdateMenu() {
        gm.SetText1("Fish" + System.Environment.NewLine + "(requires fishing rod)");
        gm.SetText2("Fill Bucket" + GenRecipeReqString(fill_bucket_recipe));
        gm.SetText3("");
        gm.SetText4("Upgrade " + GenUpgradeReqString(upgrade_recipe));
        gm.SetText5("");
        gm.SetText6("");
    }

    internal override bool AttemptInteract() {
        return true;
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                //Fish (requires fishing rod)
                if(inv.has_fishing_rod) {
                    ButcherAnimal();
                }
                break;
            case 2:
                //Fill Bucket (requires 1 Empty Bucket)
                FillBucket();
                break;
            case 3:
                //Blank
                break;
            case 4:
                //Upgrade
                AttemptUpgrade();
                break;
            case 5:
                //Blank
                break;
            case 6:
                //Blank
                break;
        }
    }

    internal void FillBucket() {
        if(fill_bucket_recipe.CheckRequirements(inv)) {
            fill_bucket_recipe.CreateResult(inv);
            gm.player.CloseMenu();
        }
    }

    internal override void ButcherAnimal(bool meddle = false) {
        base.ButcherAnimal();
        if(meddle) {
            return;
        }
        inv.UpdateItemCount(fish, 1);
        if(10 >= (int)Random.Range(0, 100)) {
            inv.UpdateItemCount(blood, 1);
        }
    }
}
