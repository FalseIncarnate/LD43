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

    internal GameManager gm;
    internal SpriteRenderer sr;
    internal Inventory inv;
    
    internal bool requires_fishing_rod = false;
    internal bool requires_pickaxe = false;

    // Use this for initialization
    void Start () {
        gm = FindObjectOfType<GameManager>();
        sr = transform.GetComponent<SpriteRenderer>();
        inv = GameObject.Find("Player_Char").GetComponent<Inventory>();

        if(!can_upgrade) {
            T1_SPRITE = T0_SPRITE;
            T2_SPRITE = T0_SPRITE;
            T3_SPRITE = T0_SPRITE;
            T4_SPRITE = T0_SPRITE;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void AttemptInteract(Inventory inv) {
        print("Interact attempt with " + object_name);
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

    internal virtual void OnUpgrade() {
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

    internal virtual void UpdateMenu() {
        gm.ToggleMenuVisibility(true);
    }

    internal virtual void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                //thing
                break;
            case 2:
                //thing
                break;
            case 3:
                //thing
                break;
            case 4:
                //thing
                break;
            case 5:
                //thing
                break;
            case 6:
                //thing
                break;
        }
    }

    internal virtual void PreClose() {

    }
}
