using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothBoltsRecipe : CraftRecipe
{
    public ClothBoltsRecipe() {
        requirements.Add(new Requirement() { product_required = new Cotton(), num_needed = 2 });
        product = new ClothBolts();
    }
}
