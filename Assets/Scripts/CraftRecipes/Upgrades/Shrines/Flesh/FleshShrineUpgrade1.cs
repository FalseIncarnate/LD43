﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleshShrineUpgrade1 : CraftRecipe
{
    public FleshShrineUpgrade1() {
        requirements.Add(new Requirement() { product_required = new Candles(), num_needed = 1 });
        money_cost = 150;
    }
}
