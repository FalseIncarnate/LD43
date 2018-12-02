using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildGrainRecipe : CraftRecipe {
    public BuildGrainRecipe () {
        requirements.Add(new Requirement() { product_required = new GrainSeed(), num_needed = 1 });
    }
}
