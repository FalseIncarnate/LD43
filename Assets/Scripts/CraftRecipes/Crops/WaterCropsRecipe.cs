using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCropsRecipe : CraftRecipe {
    public WaterCropsRecipe () {
        requirements.Add(new Requirement() { product_required = new WaterBuckets(), num_needed = 1 });
        product = new Buckets();
	}
}
