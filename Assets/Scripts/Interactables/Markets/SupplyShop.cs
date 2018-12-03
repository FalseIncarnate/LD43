using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyShop : Shop_Base {

	// Use this for initialization
	void Start () {
        object_name = "Supply Shop";
	}

    internal override void SetupShop() {
        //What the Shop sells
        shop_sells.Add(new Buckets());
        shop_sells.Add(new Barrels());
        shop_sells.Add(new Coal());
        shop_sells.Add(new Ore());
        shop_sells.Add(new Glass());
        shop_sells.Add(new MetalBars());
        shop_sells.Add(new Beeswax());
        shop_sells.Add(new Tools());

        //What the Shop will buy
        shop_buys.Add(new Wood());
        shop_buys.Add(new Coal());
        shop_buys.Add(new Ore());
        shop_buys.Add(new Glass());
        shop_buys.Add(new MetalBars());
        shop_buys.Add(new Beeswax());
        shop_buys.Add(new Tools());
    }

    internal override void BuyMenu1() {
        option1 = "Cancel Buy";
        option2 = "Buy Empty Buckets ($" + inv.GetBuyCost(shop_sells[0]) + ")";
        option3 = "Buy Empty Barrels($" + inv.GetBuyCost(shop_sells[1]) + ")";
        option4 = "Buy Coal ($" + inv.GetBuyCost(shop_sells[2]) + ")";
        option5 = "Buy Metal Ore ($" + inv.GetBuyCost(shop_sells[3]) + ")";
        option6 = "Next Page";
    }

    internal override void BuyMenu2() {
        option1 = "Prev Page";
        option2 = "Buy Glass ($" + inv.GetBuyCost(shop_sells[4]) + ")";
        option3 = "Buy Metal Bars ($" + inv.GetBuyCost(shop_sells[5]) + ")";
        option4 = "Buy Beeswax ($" + inv.GetBuyCost(shop_sells[6]) + ")";
        option5 = "Buy Tools ($" + inv.GetBuyCost(shop_sells[7]) + ")";
        option6 = "Next Page";
    }

    internal override void BuyMenu3() {
        option1 = "Prev Page";
        option2 = "Buy Fishing Rod ($25)";
        option3 = "Buy Pickaxe ($75)";
        option4 = "";
        option5 = "";
        option6 = "";
    }

    internal override void SellMenu1() {
        option1 = "Cancel Sell";
        option2 = "Sell Wood ($" + inv.GetBuyCost(shop_buys[0]) + ")";
        option3 = "Sell Coal ($" + inv.GetBuyCost(shop_buys[1]) + ")";
        option4 = "Sell Metal Ore ($" + inv.GetBuyCost(shop_buys[2]) + ")";
        option5 = "Sell Glass ($" + inv.GetBuyCost(shop_buys[3]) + ")";
        option6 = "Next Page";
    }

    internal override void SellMenu2() {
        option1 = "Prev Page";
        option2 = "Sell Metal Bars ($" + inv.GetBuyCost(shop_buys[4]) + ")";
        option3 = "Sell Beeswax ($" + inv.GetBuyCost(shop_buys[5]) + ")";
        option4 = "Sell Tools ($" + inv.GetBuyCost(shop_buys[6]) + ")";
        option5 = "";
        option6 = "";
    }

    internal override void AttemptSellToPlayer(int num) {
        if(num == 9) {
            //fishing rod
            if(inv.money >= 25 && !inv.has_fishing_rod) {
                inv.UpdateMoney(-25);
                inv.has_fishing_rod = true;
            }
            return;
        }
        if(num == 10) {
            //pickaxe
            if(inv.money >= 75 && !inv.has_pickaxe) {
                inv.UpdateMoney(-75);
                inv.has_pickaxe = true;
            }
            return;
        }
        base.AttemptSellToPlayer(num);
    }
}
