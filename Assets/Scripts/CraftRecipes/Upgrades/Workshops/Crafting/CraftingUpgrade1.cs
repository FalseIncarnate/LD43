using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUpgrade1 : CraftRecipe {
    public CraftingUpgrade1 () {
        requirements.Add(new Requirement() { product_required = new Wood(), num_needed = 10 });
        money_cost = 150;
	}
}
