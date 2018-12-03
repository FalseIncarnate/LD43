using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureRecipe : CraftRecipe
{
    public FurnitureRecipe() {
        requirements.Add(new Requirement() { product_required = new Wood(), num_needed = 3 });
        requirements.Add(new Requirement() { product_required = new ClothBolts(), num_needed = 1 });
        requirements.Add(new Requirement() { product_required = new Leather(), num_needed = 2 });
        product = new Shoes();
    }
}
