using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamRecipe : CraftRecipe {
    public JamRecipe () {
        requirements.Add(new Requirement() { product_required = new Berry(), num_needed = 1 });
        requirements.Add(new Requirement() { product_required = new Glassware(), num_needed = 1 });
        product = new Jam();
	}
}
