using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Product {
    public Wood () {
        product_name = "Wood";

        sell_value = 2;
        buy_value = 0;

        fuel_value = 5;
    }
}
