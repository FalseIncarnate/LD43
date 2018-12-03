using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelsRecipe : CraftRecipe
{
    public BarrelsRecipe() {
        requirements.Add(new Requirement() { product_required = new Wood(), num_needed = 5 });
        requirements.Add(new Requirement() { product_required = new MetalBars(), num_needed = 2 });
        product = new Barrels();
    }
}
