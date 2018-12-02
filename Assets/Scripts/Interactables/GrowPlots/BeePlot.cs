using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeePlot : GrowingPlot {

    internal CraftRecipe honey_recipe;

	// Use this for initialization
	void Start () {
        object_name = "Beehive";
        requires_water = false;
        StartCoroutine(GrowDelay(grow_interval));
        harvest = new Beeswax();
        honey_recipe = new CollectHoneyRecipe();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    internal override void Attempt_Growth() {
        if(grow_progress >= 10) {
            sr.sprite = HARVEST_SPRITE;
            return;
        }

        grow_progress++;
        CheckGrowFavorBonus();
    }

    internal override void CheckGrowFavorBonus() {
        int food_favor = gm.food_spirit_favor;
        int craft_favor = gm.craft_spirit_favor;
        int blood_favor = gm.blood_spirit_favor;

        int spirit_bonus = 0;

        if(food_favor >= 400) {
            spirit_bonus += 10;
        } else if(food_favor <= 100) {
            spirit_bonus -= 10;
        }

        if(craft_favor >= 400) {
            spirit_bonus += 15;
        } else if(craft_favor <= 100) {
            spirit_bonus -= 15;
        }

        if(blood_favor >= 400) {
            spirit_bonus += 10;
        } else if(blood_favor <= 100) {
            spirit_bonus -= 10;
        }

        if(spirit_bonus == 0) {
            return;
        }

        //low favor can stunt growth
        if(spirit_bonus < 0) {
            if(100 + spirit_bonus <= (int)Random.Range(0, 100)) {
                grow_progress--;
            }
            return;
        }

        //high favor can boost growth
        if(spirit_bonus >= (int)Random.Range(0, 100)) {
            grow_progress++;
        }
    }

    internal override void DoHarvest() {
        int craft_favor = gm.craft_spirit_favor;
        int harvest_count = 1;

        //high favor can grant double harvest
        if(craft_favor >= 450) {
            if(50 >= (int)Random.Range(0, 100)) {
                harvest_count++;
            }
        }

        //low harvest can lose harvest
        if(craft_favor <= 150) {
            GoBarren();
            return;
        }

        inv.UpdateItemCount(harvest, harvest_count);

        GoBarren();
    }

    internal override void UpdateMenu() {

    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                //Harvest Beeswax
                if(grow_progress >= HARVEST_STAGE) {
                    DoHarvest();
                }
                break;
            case 2:
                //Harvest Honey (requires glassware)
                HarvestHoney();
                break;
            case 3:
                //Blank
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

    internal void HarvestHoney() {
        if(honey_recipe.CheckRequirements(inv)){
            honey_recipe.CreateResult(inv);
        }
    }
}
