using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBeeRecipe : CraftRecipe {
    public BuildBeeRecipe () {
        requirements.Add(new Requirement() { product_required = new Wood(), num_needed = 5 });
    }
}
