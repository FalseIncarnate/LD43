using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeadRecipe : CraftRecipe {
    public MeadRecipe() {
        requirements.Add(new Requirement() { product_required = new Honey(), num_needed = 2 });
        requirements.Add(new Requirement() { product_required = new Barrels(), num_needed = 1 });
        product = new Mead();
    }
}
