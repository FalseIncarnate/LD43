using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBucketRecipe : CraftRecipe {
    public FillBucketRecipe () {
        requirements.Add(new Requirement() { product_required = new Buckets(), num_needed = 1 });
        product = new WaterBuckets();
	}
}
