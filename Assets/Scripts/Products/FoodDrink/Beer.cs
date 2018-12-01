using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : Product
{
    public Beer () {
        product_name = "Barrels of Beer";

        sell_value = 60;
        buy_value = 100;
        
        drink_value = 40;
        craft_value = 40;
    }
}
