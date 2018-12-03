using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineRecipe : CraftRecipe {
    public WineRecipe() {
        requirements.Add(new Requirement() { product_required = new Juice(), num_needed = 2 });
        requirements.Add(new Requirement() { product_required = new Barrels(), num_needed = 1 });
        product = new Wine();
    }
}
