using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalFuelRecipe : CraftRecipe {
    public CoalFuelRecipe() {
        requirements.Add(new Requirement() { product_required = new Coal(), num_needed = 1 });
    }
}
