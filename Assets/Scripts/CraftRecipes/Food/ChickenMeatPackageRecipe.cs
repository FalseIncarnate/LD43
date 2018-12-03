using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMeatPackageRecipe : CraftRecipe
{
    public ChickenMeatPackageRecipe() {
        requirements.Add(new Requirement() { product_required = new ChickenMeat(), num_needed = 1 });
        product = new MeatPackages();
    }
}
