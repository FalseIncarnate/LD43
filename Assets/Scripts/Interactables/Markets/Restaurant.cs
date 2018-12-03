using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant : Shop_Base {

	// Use this for initialization
	void Start () {
        object_name = "Restaurant";
	}

    internal override void SetupShop() {
        //What the Shop sells
        shop_sells.Add(new Flour());
        shop_sells.Add(new Eggs());
        shop_sells.Add(new MeatPackages());
        shop_sells.Add(new Bread());
        shop_sells.Add(new Cheese());
        shop_sells.Add(new Honey());
        shop_sells.Add(new Jam());
        shop_sells.Add(new Cake());
        shop_sells.Add(new Milk());
        shop_sells.Add(new Juice());
        shop_sells.Add(new Beer());
        shop_sells.Add(new Wine());
        shop_sells.Add(new Mead());

        //What the Shop will buy
        shop_buys.Add(new Flour());
        shop_buys.Add(new Eggs());
        shop_buys.Add(new MeatPackages());
        shop_buys.Add(new Bread());
        shop_buys.Add(new Cheese());
        shop_buys.Add(new Honey());
        shop_buys.Add(new Jam());
        shop_buys.Add(new Cake());
        shop_buys.Add(new Milk());
        shop_buys.Add(new Juice());
        shop_buys.Add(new Beer());
        shop_buys.Add(new Wine());
        shop_buys.Add(new Mead());
    }

    internal override void BuyMenu1() {
        option1 = "Cancel Buy";
        option2 = "Buy Flour ($" + inv.GetBuyCost(shop_sells[0]) + ")";
        option3 = "Buy Eggs ($" + inv.GetBuyCost(shop_sells[1]) + ")";
        option4 = "Buy Packaged Meat ($" + inv.GetBuyCost(shop_sells[2]) + ")";
        option5 = "Buy Bread ($" + inv.GetBuyCost(shop_sells[3]) + ")";
        option6 = "Next Page";
    }

    internal override void BuyMenu2() {
        option1 = "Prev Page";
        option2 = "Buy Cheese ($" + inv.GetBuyCost(shop_sells[4]) + ")";
        option3 = "Buy Honey ($" + inv.GetBuyCost(shop_sells[5]) + ")";
        option4 = "Buy Jam ($" + inv.GetBuyCost(shop_sells[6]) + ")";
        option5 = "Buy Cake ($" + inv.GetBuyCost(shop_sells[7]) + ")";
        option6 = "Next Page";
    }

    internal override void BuyMenu3() {
        option1 = "Prev Page";
        option2 = "Buy Milk ($" + inv.GetBuyCost(shop_sells[8]) + ")";
        option3 = "Buy Juice ($" + inv.GetBuyCost(shop_sells[9]) + ")";
        option4 = "Buy Beer ($" + inv.GetBuyCost(shop_sells[10]) + ")";
        option5 = "Buy Wine ($" + inv.GetBuyCost(shop_sells[11]) + ")";
        option6 = "Buy Mead ($" + inv.GetBuyCost(shop_sells[12]) + ")";
    }

    internal override void SellMenu1() {
        option1 = "Cancel Buy";
        option2 = "Sell Flour ($" + inv.GetSellValue(shop_buys[0]) + ")";
        option3 = "Sell Eggs ($" + inv.GetSellValue(shop_buys[1]) + ")";
        option4 = "Sell Packaged Meat ($" + inv.GetSellValue(shop_buys[2]) + ")";
        option5 = "Sell Bread ($" + inv.GetSellValue(shop_buys[3]) + ")";
        option6 = "Next Page";
    }

    internal override void SellMenu2() {
        option1 = "Prev Page";
        option2 = "Sell Cheese ($" + inv.GetSellValue(shop_buys[4]) + ")";
        option3 = "Sell Honey ($" + inv.GetSellValue(shop_buys[5]) + ")";
        option4 = "Sell Jam ($" + inv.GetSellValue(shop_buys[6]) + ")";
        option5 = "Sell Cake ($" + inv.GetSellValue(shop_buys[7]) + ")";
        option6 = "Next Page";
    }

    internal override void SellMenu3() {
        option1 = "Prev Page";
        option2 = "Sell Milk ($" + inv.GetSellValue(shop_buys[8]) + ")";
        option3 = "Sell Juice ($" + inv.GetSellValue(shop_buys[9]) + ")";
        option4 = "Sell Beer ($" + inv.GetSellValue(shop_buys[10]) + ")";
        option5 = "Sell Wine ($" + inv.GetSellValue(shop_buys[11]) + ")";
        option6 = "Sell Mead ($" + inv.GetSellValue(shop_buys[12]) + ")";
    }
}
