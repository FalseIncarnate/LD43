using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlasswareRecipe : CraftRecipe {
    public GlasswareRecipe () {
        requirements.Add(new Requirement() { product_required = new Glass(), num_needed = 2 });
        product = new Glassware();
	}
}
