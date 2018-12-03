using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShrineUpgrade2 : CraftRecipe
{
    public FoodShrineUpgrade2() {
        requirements.Add(new Requirement() { product_required = new Candles(), num_needed = 1 });
        money_cost = 150;
    }
}
