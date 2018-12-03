using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkShrineUpgrade2 : CraftRecipe
{
    public DrinkShrineUpgrade2() {
        requirements.Add(new Requirement() { product_required = new Candles(), num_needed = 1 });
        money_cost = 150;
    }
}
