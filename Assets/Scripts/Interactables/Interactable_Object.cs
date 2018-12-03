using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Object : MonoBehaviour {

    internal string object_name = "Interactive Object";

    internal bool can_upgrade = false;

    public List<CraftRecipe> upgrade_list = new List<CraftRecipe>();
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

    internal bool is_set_up = false;

    internal bool doing_activity = false;

    internal int fuel_level = 0;
    internal const int MAX_FUEL = 200;

    // Use this for initialization
    void Start() {
        
    }

    internal void Setup() {
        gm = FindObjectOfType<GameManager>();
        sr = transform.GetComponent<SpriteRenderer>();
        inv = GameObject.Find("Player_Char").GetComponent<Inventory>();

        SetupUpgrades();
        SetupRecipes();
        SetupSacrifices();
        SetupShop();

        is_set_up = true;
	}

    internal virtual void SetupUpgrades() {

    }

    internal virtual void SetupRecipes() {

    }

    internal virtual void SetupSacrifices() {

    }

    internal virtual void SetupShop() {

    }

    // Update is called once per frame
    void Update () {
        if(!is_set_up) {
            Setup();
        }
	}

    internal virtual bool AttemptInteract() {
        print("Failed Interact Attempt with " + object_name);
        return false;
    }

    internal string GenUpgradeReqString(CraftRecipe upgrade_recipe) {
        if(!can_upgrade || upgrade_recipe == null) {
            return (System.Environment.NewLine + "(Can't Upgrade)");
        }
        if(upgrade_level == max_upgrade_level) {
            return (System.Environment.NewLine + "(Max Upgrade Level)");
        }

        string req_string = (System.Environment.NewLine + "(requires");
        foreach(Requirement req in upgrade_recipe.requirements) {
            req_string += (" " + req.num_needed + " " + req.product_required.product_name);
        }
        if(upgrade_recipe.money_cost > 0) {
            req_string += (" $" + upgrade_recipe.money_cost);
        }
        req_string += ")";

        return req_string;
    }

    internal string GenRecipeReqString(CraftRecipe craft_recipe) {
        string req_string = (System.Environment.NewLine + "(requires");
        foreach(Requirement req in craft_recipe.requirements) {
            req_string += (" " + req.num_needed + " " + req.product_required.product_name);
        }
        if(craft_recipe.money_cost > 0) {
            req_string += (" $" + craft_recipe.money_cost);
        }
        req_string += ")";

        return req_string;
    }

    internal void AttemptUpgrade() {
        if(!can_upgrade || upgrade_recipe == null) {
            return;
        }
        if(upgrade_level == max_upgrade_level) {
            return;
        }
        if(!upgrade_recipe.CheckRequirements(inv)) {
            return;
        }
        DoUpgrade();
    }

    internal void DoUpgrade() {
        upgrade_recipe.ConsumeCost(inv);
        upgrade_level++;
        OnUpgrade();
        gm.player.CloseMenu();
    }

    internal virtual void OnUpgrade() {
        if(upgrade_level != max_upgrade_level) {
            upgrade_recipe = upgrade_list[upgrade_level];
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
        if(gm.doing_activity) {
            return;
        }
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

    internal void StartActivity(string action_message = "Action In Progress") {
        gm.action_menu_layout.SetActive(true);
        gm.action_text.text = action_message;
        gm.basic_menu_layout.SetActive(false);
        ActivityDelay();
    }

    internal void ActivityDelay() {
        gm.activity_step_count = 0;
        gm.action_progress.text = ".";
        StartCoroutine(ActivityDelayInterval(1));
    }

    internal void ActivityStep() {
        //print("ActivityStep, count: " + gm.activity_step_count);
        if(gm.activity_step_count == 3) {
            ActivityFinish();
            return;
        }
        gm.activity_step_count++;
        gm.action_progress.text += " .";
        StartCoroutine(ActivityDelayInterval(1));
    }

    internal virtual void ActivityFinish() {
        gm.action_menu_layout.SetActive(false);
        gm.basic_menu_layout.SetActive(true);
        gm.player.CloseMenu();
    }

    internal IEnumerator ActivityDelayInterval(float seconds) {
        if(gm.doing_activity) {
            yield break;
        }

        gm.doing_activity = true;

        yield return new WaitForSeconds(seconds);

        gm.doing_activity = false;

        ActivityStep();
    }

    internal virtual void Tantrum() {
        upgrade_recipe = upgrade_list[upgrade_level];
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
        }
    }
}
