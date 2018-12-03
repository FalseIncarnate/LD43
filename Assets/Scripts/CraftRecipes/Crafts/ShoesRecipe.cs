using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoesRecipe : CraftRecipe
{
    public ShoesRecipe() {
        requirements.Add(new Requirement() { product_required = new Leather(), num_needed = 2 });
        requirements.Add(new Requirement() { product_required = new Wood(), num_needed = 1 });
        product = new Shoes();
    }
}
