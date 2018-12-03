using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseRecipe : CraftRecipe
{
    public CheeseRecipe() {
        requirements.Add(new Requirement() { product_required = new Milk(), num_needed = 1 });
        product = new Cheese();
    }
}
