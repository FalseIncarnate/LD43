using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBucketRecipe : CraftRecipe {
    public EmptyBucketRecipe () {
        requirements.Add(new Requirement() { product_required = new Wood(), num_needed = 2 });
        product = new Buckets();
	}
}
