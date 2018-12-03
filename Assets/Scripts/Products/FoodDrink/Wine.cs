using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wine : Product
{
    public Wine () {
        product_name = "Barrels of Wine";

        sell_value = 125;
        buy_value = 150;

        drink_value = 55;
        craft_value = 70;
    }
}
