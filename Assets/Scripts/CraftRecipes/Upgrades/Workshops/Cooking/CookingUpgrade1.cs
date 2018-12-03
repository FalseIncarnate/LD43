using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingUpgrade1 : CraftRecipe {
    public CookingUpgrade1 () {
        requirements.Add(new Requirement() { product_required = new Glassware(), num_needed = 2 });
        requirements.Add(new Requirement() { product_required = new Wood(), num_needed = 10 });
        money_cost = 250;
	}
}
