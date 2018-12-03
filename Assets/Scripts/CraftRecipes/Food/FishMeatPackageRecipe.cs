using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMeatPackageRecipe : CraftRecipe
{
    public FishMeatPackageRecipe() {
        requirements.Add(new Requirement() { product_required = new Fish(), num_needed = 1 });
        product = new MeatPackages();
    }
}
