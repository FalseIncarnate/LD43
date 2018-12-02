using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class GrowingPlot : Interactable_Object {

    internal bool requires_water = true;
    public GameObject empty_plot;

    public Sprite GROW_SPRITE;
    public Sprite DRY_SPRITE;
    public Sprite HARVEST_SPRITE;

    internal int water_level = 50;
    internal const int DRY_LEVEL = 20;

    internal int grow_progress = 0;
    internal const int HARVEST_STAGE = 10;
    internal float grow_interval = 10;
    internal bool is_growing = false;

    public Product harvest;
    public Product seedtype;

    internal CraftRecipe water_crops_recipe;

    // Use this for initialization
    void Start () {
        object_name = "Growing Plot";
        StartCoroutine(GrowDelay(grow_interval));
        water_crops_recipe = new WaterCropsRecipe();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal IEnumerator GrowDelay(float seconds) {
        if(is_growing) {
            yield break;
        }

        is_growing = true;

        yield return new WaitForSeconds(seconds);

        is_growing = false;

        Attempt_Growth();
        
    }

    internal virtual void Attempt_Growth() {
        if(grow_progress >= HARVEST_STAGE) {
            sr.sprite = HARVEST_SPRITE;
            return;
        }

        if(water_level > 0) {
            water_level -= 5;
        }
        
        if(water_level <= 0) {
            //Become empty (plant died from dehydration)
            GoBarren();
            return;
        }

        //this is after the dehydration check so you get an extra interval before going barren to water if the spirits cause droughts
        CheckWaterFavorBonus(); 

        if(water_level <= DRY_LEVEL) {
            sr.sprite = DRY_SPRITE;
        } else {
            sr.sprite = GROW_SPRITE;
        }

        if(water_level > DRY_LEVEL) {
            grow_progress++;
            CheckGrowFavorBonus();
            if(grow_progress >= HARVEST_STAGE) {
                sr.sprite = HARVEST_SPRITE;
            }
        }

        StartCoroutine(GrowDelay(grow_interval));
    }

    internal virtual void CheckGrowFavorBonus() {
        int produce_favor = gm.produce_spirit_favor;
        int blood_favor = gm.blood_spirit_favor;

        int spirit_bonus = 0;

        if(produce_favor >= 400) {
            spirit_bonus += 25;
        }else if(produce_favor <= 100) {
            spirit_bonus -= 25;
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
            if(100 + spirit_bonus <= (int)Random.Range(0, 100)){
                grow_progress--;  
            }
            return;
        }

        //high favor can boost growth
        if(spirit_bonus >= (int)Random.Range(0, 100)) {
            grow_progress++;
        }
    }

    internal void CheckWaterFavorBonus() {
        int drink_favor = gm.drink_spirit_favor;
        int blood_favor = gm.blood_spirit_favor;

        int spirit_bonus = 0;
        int bonus_water = 0;

        if(drink_favor >= 400) {
            spirit_bonus += 10;
            bonus_water += 10;
        } else if(drink_favor <= 100) {
            spirit_bonus -= 10;
            bonus_water -= 5;
        }
        if(blood_favor >= 400) {
            spirit_bonus += 10;
            bonus_water += 5;
        } else if(blood_favor <= 100) {
            spirit_bonus -= 10;
            bonus_water -= 5;
        }

        if(spirit_bonus == 0 || bonus_water == 0) {
            return;
        }

        //low favor can cause droughts
        if(spirit_bonus < 0) {
            if(100 + spirit_bonus <= (int)Random.Range(0, 100)) {
                water_level += bonus_water;
            }
            return;
        }

        //high favor can grant rain
        if(spirit_bonus >= (int)Random.Range(0, 100)) {
            water_level += bonus_water;
        }
    }

    internal void GoBarren() {
        Instantiate(empty_plot, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    internal virtual void DoHarvest() {
        int produce_favor = gm.produce_spirit_favor;
        int harvest_count = 1;

        //high favor can grant double harvest or a free seed with harvest
        if(produce_favor >= 450) {
            if(50 >= (int)Random.Range(0, 100)){
                harvest_count++;
            } else {
                inv.UpdateItemCount(seedtype, harvest_count);
            }
        }

        //low harvest refunds the seed but no harvest
        if(produce_favor <= 150) {
            inv.UpdateItemCount(seedtype, harvest_count);
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
                //Harvest
                if(grow_progress >= HARVEST_STAGE) {
                    DoHarvest();
                }
                break;
            case 2:
                //Water Crops
                WaterCrops();
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
                //Remove Crop
                GoBarren();
                break;
        }
    }

    internal void WaterCrops() {
        if(water_crops_recipe.CheckRequirements(inv)) {
            water_crops_recipe.CreateResult(inv);
            water_level += 25;
        }
        //update sprite on attempt, regardless of success
        if(water_level <= DRY_LEVEL) {
            sr.sprite = DRY_SPRITE;
        } else {
            sr.sprite = GROW_SPRITE;
        }
    }
}
