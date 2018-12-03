using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodFuelRecipe : CraftRecipe {
    public WoodFuelRecipe () {
        requirements.Add(new Requirement() { product_required = new Wood(), num_needed = 1 });
	}
}
