using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCornRecipe : CraftRecipe {
    public BuildCornRecipe () {
        requirements.Add(new Requirement() { product_required = new CornSeed(), num_needed = 1 });
    }
}
