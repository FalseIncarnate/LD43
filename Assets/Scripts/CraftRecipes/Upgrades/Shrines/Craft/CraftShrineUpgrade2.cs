using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftShrineUpgrade2 : CraftRecipe
{
    public CraftShrineUpgrade2() {
        requirements.Add(new Requirement() { product_required = new Candles(), num_needed = 1 });
        money_cost = 150;
    }
}
