using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkShrineUpgrade3 : CraftRecipe
{
    public DrinkShrineUpgrade3() {
        requirements.Add(new Requirement() { product_required = new Candles(), num_needed = 1 });
        money_cost = 150;
    }
}
