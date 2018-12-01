using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mead : Product
{
    public Mead () {
        product_name = "Barrels of Mead";

        sell_value = 150;
        buy_value = 200;

        drink_value = 70;
        craft_value = 55;
    }
}
