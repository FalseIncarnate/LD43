using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUpgrade3 : CraftRecipe
{
    public CraftingUpgrade3() {
        requirements.Add(new Requirement() { product_required = new Wood(), num_needed = 5 });
        requirements.Add(new Requirement() { product_required = new Tools(), num_needed = 5 });
        money_cost = 250;
    }
}
