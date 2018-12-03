using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBarsRecipe : CraftRecipe {
    public MetalBarsRecipe(){
        requirements.Add(new Requirement() { product_required = new Ore(), num_needed = 2 });
        product = new MetalBars();
    }
}
