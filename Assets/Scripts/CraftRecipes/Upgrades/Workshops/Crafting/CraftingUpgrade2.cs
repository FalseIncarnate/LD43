using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUpgrade2 : CraftRecipe
{
    public CraftingUpgrade2() {
        requirements.Add(new Requirement() { product_required = new Wood(), num_needed = 5 });
        requirements.Add(new Requirement() { product_required = new Tools(), num_needed = 1 });
        money_cost = 200;
    }
}
