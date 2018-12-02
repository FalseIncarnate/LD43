using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPen : AnimalPen {

	// Use this for initialization
	void Start () {
        object_name = "Fish Pond";
        requires_feed = false;
        requires_fishing_rod = true;
        max_mature_animals = 5;

        upgrade_list = new List<CraftRecipe>();
        upgrade_list.Add(new FishUpgrade1());
        upgrade_list.Add(new FishUpgrade2());
        upgrade_list.Add(new FishUpgrade3());
        upgrade_list.Add(new FishUpgrade4());

        upgrade_recipe = upgrade_list[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    internal override void OnUpgrade() {
        base.OnUpgrade();
        switch(upgrade_level) {
            case 0:
                max_mature_animals = 5;
                maturity_rate = 90;
                break;
            case 1:
                max_mature_animals = 10;
                maturity_rate = 90;
                break;
            case 2:
                max_mature_animals = 15;
                maturity_rate = 75;
                break;
            case 3:
                max_mature_animals = 20;
                maturity_rate = 75;
                break;
            case 4:
                max_mature_animals = 25;
                maturity_rate = 60;
                break;
        }
    }
}
