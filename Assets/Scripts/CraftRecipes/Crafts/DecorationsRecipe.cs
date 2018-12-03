using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationsRecipe : CraftRecipe
{
    public DecorationsRecipe() {
        requirements.Add(new Requirement() { product_required = new Glass(), num_needed = 1 });
        requirements.Add(new Requirement() { product_required = new MetalBars(), num_needed = 2 });
        product = new Decorations();
    }
}
