using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftRecipe {

    internal List<Requirement> requirements;
    protected Product product;
    internal int money_cost = 0;

    // Use this for initialization
    void Start () {
        // requirements.Add(new Requirement() { product_required = new Product(), num_needed = 1 });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    internal bool CheckRequirements(Inventory inv) {
        if(money_cost > 0 && (money_cost > inv.money)) {
            return false;
        }
        bool meet_requirements = true;
        if(requirements.Count > 0) {
            foreach(Requirement req in requirements) {
                if(!inv.CheckRequiredItems(this)) {
                    meet_requirements = false;
                    break;
                }
            }
        }
        return meet_requirements;
    }

    internal void ConsumeCost(Inventory inv) {
        if(money_cost > 0) {
            inv.UpdateMoney(money_cost * -1);
        }
        foreach(Requirement req_entry in requirements) {
            Product thing_needed = req_entry.product_required;
            int num_needed = req_entry.num_needed;
            inv.UpdateItemCount(thing_needed, (num_needed * -1));
        }
    }

    internal void CreateResult(Inventory inv) {
        ConsumeCost(inv);
        inv.UpdateItemCount(product, 1);
    }

}

public class Requirement
{
    public Product product_required { get; set; }
    public int num_needed { get; set; }
}
