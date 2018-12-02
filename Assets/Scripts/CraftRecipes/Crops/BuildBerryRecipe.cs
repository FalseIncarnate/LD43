using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBerryRecipe : CraftRecipe {
    public BuildBerryRecipe () {
        requirements.Add(new Requirement() { product_required = new BerrySeed(), num_needed = 1 });
    }
}
