using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourRecipe : CraftRecipe {
    public FlourRecipe () {
        requirements.Add(new Requirement() { product_required = new Grain(), num_needed = 1 });
        product = new Flour();
	}
}
