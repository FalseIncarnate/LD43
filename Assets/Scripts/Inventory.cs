using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{

    //inventory list, each entry is a product data and the number owned
    internal List<InvEntry> my_inv;

    //money: buy products, upgrade pens, pay taxes
    internal int money = 100;

    //Buyable tools/equipment flags
    internal bool has_fishing_rod = false;
    internal bool has_pickaxe = false;

    // Use this for initialization
    void Start() {
        my_inv = new List<InvEntry>();
        BuildInvList();

        foreach(InvEntry ie in my_inv) {
            ie.product_data.CalcPrices();
            //print(ie.product_data.product_name + " Sell: " + ie.product_data.sell_value + ", Buy: " + ie.product_data.buy_value);
        }

    }

    // Update is called once per frame
    void Update() {

    }

    void BuildInvList() {
        BuildSeedList();
        BuildProduceList();
        BuildAnimalList();
        BuildFoodDrinkList();
        BuildCraftList();
        BuildResourceList();
    }

    void BuildSeedList() {
        my_inv.Add(new InvEntry() { product_data = new CornSeed(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new GrainSeed(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new CottonSeed(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new BerrySeed(), product_owned = 0 });
    }

    void BuildProduceList() {
        my_inv.Add(new InvEntry() { product_data = new Corn(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Grain(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Cotton(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Berry(), product_owned = 0 });
    }

    void BuildAnimalList() {
        my_inv.Add(new InvEntry() { product_data = new Beef(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Leather(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new ChickenMeat(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Fish(), product_owned = 0 });
    }

    void BuildFoodDrinkList() {
        //Food
        my_inv.Add(new InvEntry() { product_data = new Flour(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Eggs(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Honey(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Cheese(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Bread(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Cake(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Jam(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new MeatPackages(), product_owned = 0 });
        //Drinks
        my_inv.Add(new InvEntry() { product_data = new Milk(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Juice(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Beer(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Wine(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Mead(), product_owned = 0 });
    }

    void BuildCraftList() {
        my_inv.Add(new InvEntry() { product_data = new ClothBolts(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new ClothGoods(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Shoes(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Buckets(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Barrels(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Furniture(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Glassware(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Decorations(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Tools(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Candles(), product_owned = 0 });
    }

    void BuildResourceList() {
        my_inv.Add(new InvEntry() { product_data = new Blood(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Wood(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Ore(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new MetalBars(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Glass(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Coal(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new Beeswax(), product_owned = 0 });
        my_inv.Add(new InvEntry() { product_data = new WaterBuckets(), product_owned = 1 });
    }

    internal bool CheckRequiredItems(CraftRecipe recipe) {
        if(recipe == null) {
            return false;
        }

        if(recipe.requirements.Count == 0) {
            return true;
        }

        bool have_enough = false;
        foreach(Requirement req_entry in recipe.requirements) {
            Product thing_needed = req_entry.product_required;
            int num_needed = req_entry.num_needed;
            foreach(InvEntry ie in my_inv) {
                if(ie.product_data.GetType() == thing_needed.GetType()) {
                    if(ie.product_owned >= num_needed) {
                        have_enough = true;
                        break;
                    }
                }
            }
        }
        return have_enough;
    }

    internal void UpdateItemCount(Product thing_to_update, int num_change) {
        if(thing_to_update == null) {
            return;
        }
        foreach(InvEntry ie in my_inv) {
            if(ie.product_data.GetType() == thing_to_update.GetType()) {
                ie.product_owned = Math.Max(0, ie.product_owned + num_change);
                break;
            }
        }

    }

    internal void UpdateMoney(int change) {
        money += change;
    }

}

public class InvEntry
{
    public Product product_data { get; set; }
    public int product_owned { get; set; }
}
