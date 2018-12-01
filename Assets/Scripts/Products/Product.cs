using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Product {

    internal string product_name = "Thing";

    internal int sell_value = 0;
    internal int buy_value = -1;

    internal int food_value = 0;
    internal int drink_value = 0;
    internal int produce_value = 0;
    internal int flesh_value = 0;
    internal int craft_value = 0;
    internal int blood_value = 0;

    internal int fuel_value = 0;

    internal void CalcPrices () {
		if(buy_value == -1) {
            buy_value = (int)Math.Round(sell_value * 1.25);
        }
	}
}
