using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPen : Interactable_Object
{
    internal bool requires_feed = true;
    internal List<Product> feed_product;
    internal bool is_fed = false;

    internal int maturity_rate = 90;
    internal int mature_animals = 0;
    internal int max_mature_animals = 3;

    internal int maturity_progress = 0;

	// Use this for initialization
	void Start () {
        object_name = "Animal Pen";
        can_upgrade = true;
        max_upgrade_level = 4;
    }

    // Update is called once per frame
    void Update() {

    }

}
