using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPlot : Interactable_Object {

    internal CraftRecipe make_bee_recipe;
    public GameObject bee_plot_prefab;

    internal CraftRecipe make_berry_recipe;
    public GameObject berry_plot_prefab;

    internal CraftRecipe make_corn_recipe;
    public GameObject corn_plot_prefab;

    internal CraftRecipe make_cotton_recipe;
    public GameObject cotton_plot_prefab;

    internal CraftRecipe make_grain_recipe;
    public GameObject grain_plot_prefab;

    // Use this for initialization
    void Start () {
        object_name = "Farm Plot";

        make_bee_recipe = new BuildBeeRecipe();
        make_berry_recipe = new BuildBerryRecipe();
        make_corn_recipe = new BuildCornRecipe();
        make_cotton_recipe = new BuildCottonRecipe();
        make_grain_recipe = new BuildGrainRecipe();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    internal override void UpdateMenu() {
        
    }

    internal override void HandleMenuOption(int option) {
        switch(option) {
            case 1:
                //Build Beehive
                BuildBeehive();
                break;
            case 2:
                //Plant Berries
                PlantBerries();
                break;
            case 3:
                //Plant Corn
                PlantCorn();
                break;
            case 4:
                //Plant Cotton
                PlantCotton();
                break;
            case 5:
                //Plant Grain
                PlantGrain();
                break;
            case 6:
                //blank
                break;
        }
    }

    void BuildBeehive() {
        if(make_bee_recipe.CheckRequirements(inv)) {
            make_bee_recipe.ConsumeCost(inv);
            Instantiate(bee_plot_prefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void PlantBerries() {
        if(make_berry_recipe.CheckRequirements(inv)) {
            make_berry_recipe.ConsumeCost(inv);
            Instantiate(berry_plot_prefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void PlantCorn() {
        if(make_corn_recipe.CheckRequirements(inv)) {
            make_corn_recipe.ConsumeCost(inv);
            Instantiate(corn_plot_prefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void PlantCotton() {
        if(make_cotton_recipe.CheckRequirements(inv)) {
            make_cotton_recipe.ConsumeCost(inv);
            Instantiate(cotton_plot_prefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void PlantGrain() {
        if(make_grain_recipe.CheckRequirements(inv)) {
            make_grain_recipe.ConsumeCost(inv);
            Instantiate(grain_plot_prefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
