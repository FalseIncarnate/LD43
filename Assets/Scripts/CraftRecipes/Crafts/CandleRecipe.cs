using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleRecipe : CraftRecipe
{
    public CandleRecipe() {
        requirements.Add(new Requirement() { product_required = new Beeswax(), num_needed = 2 });
        product = new Candles();
    }
}
