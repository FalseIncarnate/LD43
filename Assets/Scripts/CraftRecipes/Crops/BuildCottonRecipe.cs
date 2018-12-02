using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCottonRecipe : CraftRecipe {
    public BuildCottonRecipe () {
        requirements.Add(new Requirement() { product_required = new CottonSeed(), num_needed = 1 });
    }
}
