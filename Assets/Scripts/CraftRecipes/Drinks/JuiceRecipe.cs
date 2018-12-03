using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceRecipe : CraftRecipe {
    public JuiceRecipe () {
        requirements.Add(new Requirement() { product_required = new Berry(), num_needed = 1 });
        product = new Juice();
	}
}
