using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadRecipe : CraftRecipe
{
    public BreadRecipe() {
        requirements.Add(new Requirement() { product_required = new Flour(), num_needed = 1 });
        product = new Bread();
    }
}
