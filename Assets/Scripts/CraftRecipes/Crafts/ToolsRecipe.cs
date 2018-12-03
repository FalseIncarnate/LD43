using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsRecipe : CraftRecipe
{
    public ToolsRecipe() {
        requirements.Add(new Requirement() { product_required = new MetalBars(), num_needed = 1 });
        requirements.Add(new Requirement() { product_required = new Wood(), num_needed = 1 });
        product = new Tools();
    }
}
