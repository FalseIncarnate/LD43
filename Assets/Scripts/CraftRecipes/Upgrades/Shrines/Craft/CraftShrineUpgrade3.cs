using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftShrineUpgrade3 : CraftRecipe
{
    public CraftShrineUpgrade3() {
        requirements.Add(new Requirement() { product_required = new Candles(), num_needed = 1 });
        money_cost = 150;
    }
}
