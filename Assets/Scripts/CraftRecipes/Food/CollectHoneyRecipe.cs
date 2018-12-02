using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHoneyRecipe : CraftRecipe {
    public CollectHoneyRecipe () {
        requirements.Add(new Requirement() { product_required = new Glassware(), num_needed = 1 });
        product = new Honey();
	}
}
