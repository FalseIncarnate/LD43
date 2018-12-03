using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChickenPen : AnimalPen {

    internal Product egg = new Eggs();
    internal Product chicken_meat = new ChickenMeat();

	// Use this for initialization
	void Start () {
        object_name = "Chicken Coop";
        requires_feed = true;
        feed_product = new Corn();
        max_mature_animals = 4;
        maturity_rate = 10;
        StartCoroutine(MatureDelay(maturity_rate));
    }

    internal override void SetupUpgrades() {
        base.SetupUpgrades();
        
        upgrade_list.Add(new ChickenUpgrade1());
        upgrade_list.Add(new ChickenUpgrade2());
        upgrade_list.Add(new ChickenUpgrade3());
        upgrade_list.Add(new ChickenUpgrade4());

        upgrade_recipe = upgrade_list[0];
    }

    internal override void OnUpgrade() {
        base.OnUpgrade();
        switch(upgrade_level) {
            case 0:
                max_mature_animals = 4;
                maturity_rate = 10;
                break;
            case 1:
                max_mature_animals = 8;
                maturity_rate = 10;
                break;
            case 2:
                max_mature_animals = 12;
                maturity_rate = 8;
                break;
            case 3:
                max_mature_animals = 16;
                maturity_rate = 8;
                break;
            case 4:
                max_mature_animals = 20;
                maturity_rate = 6;
                break;
        }
    }

    internal override void UpdateMenu() {
        gm.SetText1("Butcher Chicken");
        gm.SetText2("Search for Eggs (chance)");
        gm.SetText3("Feed" + System.Environment.NewLine + "(requires 1 Corn)");
        gm.SetText4("");
        gm.SetText5("Upgrade " + GenUpgradeReqString(upgrade_recipe));
        gm.SetText6("");
    }

    internal override bool AttemptInteract() {
        return true;
    }

    internal override void HandleMenuOption(int option) {
        if(gm.doing_activity) {
            return;
        }
        switch(option) {
            case 1:
                //Butcher Chicken
                gm.player.CloseMenu();
                if(mature_animals > 0) {
                    ButcherAnimal();
                }
                break;
            case 2:
                //Search for Eggs (chance)
                StartActivity("Searching for Eggs");
                break;
            case 3:
                //Feed (requires 1 Corn);
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

    internal override void ActivityFinish() {
        base.ActivityFinish();
        if((5 + (mature_animals * 4)) >= (int)Random.Range(0, 100)){
            inv.UpdateItemCount(egg, (int)Random.Range(1, 3));
        }
    }

    internal override void ButcherAnimal(bool meddle = false) {
        base.ButcherAnimal();
        if(meddle) {
            return;
        }
        inv.UpdateItemCount(chicken_meat, 1);
        if(50 >= (int)Random.Range(0, 100)) {
            inv.UpdateItemCount(blood, 1);
        }
    }
}
