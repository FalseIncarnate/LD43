using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Object : MonoBehaviour {

    internal string object_name = "Interactive Object";

    internal bool can_upgrade = false;

    public List<CraftRecipe> upgrade_list;
    internal CraftRecipe upgrade_recipe;
    internal int upgrade_level = 0;
    internal int max_upgrade_level = 0;

    public Sprite T0_SPRITE;
    public Sprite T1_SPRITE;
    public Sprite T2_SPRITE;
    public Sprite T3_SPRITE;
    public Sprite T4_SPRITE;

    internal SpriteRenderer sr;

    internal bool requires_fishing_rod = false;
    internal bool requires_pickaxe = false;

    // Use this for initialization
    void Start () {
        sr = transform.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void AttemptInteract(Inventory inv) {
        
    }

    internal void AttemptUpgrade(Inventory inv) {
        if(!can_upgrade) {
            return;
        }
        if(upgrade_level == max_upgrade_level) {
            return;
        }
        if(!inv.CheckRequiredItems(upgrade_recipe)) {
            return;
        }
        DoUpgrade(inv);
        return;
    }

    internal void DoUpgrade(Inventory inv) {
        upgrade_recipe.ConsumeCost(inv);
        upgrade_level++;
        OnUpgrade();
    }

    internal void OnUpgrade() {
        if(upgrade_level != max_upgrade_level) {
            upgrade_recipe = upgrade_list[upgrade_level - 1];
        }
        switch(upgrade_level) {
            case 0:
                sr.sprite = T0_SPRITE;
                break;
            case 1:
                sr.sprite = T1_SPRITE;
                break;
            case 2:
                sr.sprite = T2_SPRITE;
                break;
            case 3:
                sr.sprite = T3_SPRITE;
                break;
            case 4:
                sr.sprite = T4_SPRITE;
                break;
        }
    }
}
