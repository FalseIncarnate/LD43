using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftShrineUpgrade4 : CraftRecipe
{
    public CraftShrineUpgrade4() {
        requirements.Add(new Requirement() { product_required = new Candles(), num_needed = 1 });
        money_cost = 150;
    }
}
