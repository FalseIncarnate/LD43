using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftFair : Shop_Base {

	// Use this for initialization
	void Start () {
        object_name = "Craft Fair";
	}

    internal override void SetupShop() {
        //What the Shop sells
        shop_sells.Add(new Candles());
        shop_sells.Add(new ClothBolts());
        shop_sells.Add(new ClothGoods());
        shop_sells.Add(new Shoes());
        shop_sells.Add(new Glassware());
        shop_sells.Add(new Decorations());
        shop_sells.Add(new Furniture());

        //What the Shop will buy
        shop_buys.Add(new Candles());
        shop_buys.Add(new ClothBolts());
        shop_buys.Add(new ClothGoods());
        shop_buys.Add(new Shoes());
        shop_buys.Add(new Glassware());
        shop_buys.Add(new Decorations());
        shop_buys.Add(new Furniture());
    }

    internal override void BuyMenu1() {
        option1 = "Cancel Buy";
        option2 = "Buy Candles ($" + inv.GetBuyCost(shop_sells[0]) + ")";
        option3 = "Buy Cloth Bolts ($" + inv.GetBuyCost(shop_sells[1]) + ")";
        option4 = "Buy Cloth Goods ($" + inv.GetBuyCost(shop_sells[2]) + ")";
        option5 = "Buy Shoes ($" + inv.GetBuyCost(shop_sells[3]) + ")";
        option6 = "Next Page";
    }

    internal override void BuyMenu2() {
        option1 = "Prev Page";
        option2 = "Buy Glassware ($" + inv.GetBuyCost(shop_sells[4]) + ")";
        option3 = "Buy Decorations ($" + inv.GetBuyCost(shop_sells[5]) + ")";
        option4 = "Buy Furniture ($" + inv.GetBuyCost(shop_sells[6]) + ")";
        option5 = "";
        option6 = "";
    }

    internal override void SellMenu1() {
        option1 = "Cancel Sell";
        option2 = "Sell Candles ($" + inv.GetBuyCost(shop_sells[0]) + ")";
        option3 = "Sell Cloth Bolts ($" + inv.GetBuyCost(shop_sells[1]) + ")";
        option4 = "Sell Cloth Goods ($" + inv.GetBuyCost(shop_sells[2]) + ")";
        option5 = "Sell Shoes ($" + inv.GetBuyCost(shop_sells[3]) + ")";
        option6 = "Next Page";
    }

    internal override void SellMenu2() {
        option1 = "Prev Page";
        option2 = "Sell Glassware ($" + inv.GetBuyCost(shop_sells[4]) + ")";
        option3 = "Sell Decorations ($" + inv.GetBuyCost(shop_sells[5]) + ")";
        option4 = "Sell Furniture ($" + inv.GetBuyCost(shop_sells[6]) + ")";
        option5 = "";
        option6 = "";
    }
}
