using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerRecipe : CraftRecipe {
    public BeerRecipe() {
        requirements.Add(new Requirement() { product_required = new Grain(), num_needed = 2 });
        requirements.Add(new Requirement() { product_required = new Barrels(), num_needed = 1 });
        product = new Beer();
    }
}
