using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefMeatPackageRecipe : CraftRecipe
{
    public BeefMeatPackageRecipe() {
        requirements.Add(new Requirement() { product_required = new Beef(), num_needed = 1 });
        product = new MeatPackages();
    }
}
