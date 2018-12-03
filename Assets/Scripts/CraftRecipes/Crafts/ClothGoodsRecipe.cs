using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothGoodsRecipe : CraftRecipe
{
    public ClothGoodsRecipe() {
        requirements.Add(new Requirement() { product_required = new ClothBolts(), num_needed = 2 });
        product = new ClothGoods();
    }
}
