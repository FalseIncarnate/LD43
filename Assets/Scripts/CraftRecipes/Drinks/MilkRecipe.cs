using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkRecipe : CraftRecipe {
    public MilkRecipe () {
        requirements.Add(new Requirement() { product_required = new Buckets(), num_needed = 1 });
        product = new Milk();
	}
}
