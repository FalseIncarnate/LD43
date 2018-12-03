using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodShrineUpgrade3 : CraftRecipe
{
    public FoodShrineUpgrade3() {
        requirements.Add(new Requirement() { product_required = new Candles(), num_needed = 1 });
        money_cost = 150;
    }
}
