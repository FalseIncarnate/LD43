using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeRecipe : CraftRecipe
{
    public CakeRecipe() {
        requirements.Add(new Requirement() { product_required = new Flour(), num_needed = 2 });
        requirements.Add(new Requirement() { product_required = new Eggs(), num_needed = 1 });
        requirements.Add(new Requirement() { product_required = new Milk(), num_needed = 1 });
        product = new Cake();
    }
}
