using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceStand : Shop_Base {

	// Use this for initialization
	void Start () {
        object_name = "Produce Stall";
	}
	
	internal override void SetupShop() {
        //What the Shop sells
        shop_sells.Add(new BerrySeed());
        shop_sells.Add(new CornSeed());
        shop_sells.Add(new CottonSeed());
        shop_sells.Add(new GrainSeed());
        shop_sells.Add(new Berry());
        shop_sells.Add(new Corn());
        shop_sells.Add(new Cotton());
        shop_sells.Add(new Grain());

        //What the Shop will buy
        shop_buys.Add(new Berry());
        shop_buys.Add(new Corn());
        shop_buys.Add(new Cotton());
        shop_buys.Add(new Grain());
    }

    internal override void BuyMenu1() {
        option1 = "Cancel Buy";
        option2 = "Buy Berry Seeds ($" + inv.GetBuyCost(shop_sells[0]) + ")";
        option3 = "Buy Corn Seeds ($" + inv.GetBuyCost(shop_sells[1]) + ")";
        option4 = "Buy Cotton Seeds ($" + inv.GetBuyCost(shop_sells[2]) + ")";
        option5 = "Buy Grain Seeds ($" + inv.GetBuyCost(shop_sells[3]) + ")";
        option6 = "Next Page";
    }

    internal override void BuyMenu2() {
        option1 = "Prev Page";
        option2 = "Buy Berries ($" + inv.GetBuyCost(shop_sells[4]) + ")";
        option3 = "Buy Corn ($" + inv.GetBuyCost(shop_sells[5]) + ")";
        option4 = "Buy Cotton ($" + inv.GetBuyCost(shop_sells[6]) + ")";
        option5 = "Buy Grain ($" + inv.GetBuyCost(shop_sells[7]) + ")";
        option6 = "";
    }

    internal override void SellMenu1() {
        option1 = "Cancel Sell ($" + inv.GetSellValue(shop_buys[0]) + ")";
        option2 = "Sell Berries ($" + inv.GetSellValue(shop_buys[1]) + ")";
        option3 = "Sell Corn ($" + inv.GetSellValue(shop_buys[2]) + ")";
        option4 = "Sell Cotton ($" + inv.GetSellValue(shop_buys[3]) + ")";
        option5 = "Sell Grain ($" + inv.GetSellValue(shop_buys[4]) + ")";
        option6 = "";
    }
}
