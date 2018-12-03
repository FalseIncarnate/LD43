using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingUpgrade2 : CraftRecipe
{
    public BrewingUpgrade2() {
        requirements.Add(new Requirement() { product_required = new Barrels(), num_needed = 1 });
        requirements.Add(new Requirement() { product_required = new WaterBuckets(), num_needed = 2 });
        money_cost = 250;
    }
}
