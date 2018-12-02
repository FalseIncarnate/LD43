using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryPlot : GrowingPlot {

	// Use this for initialization
	void Start () {
        object_name = "Berry Patch";
        StartCoroutine(GrowDelay(grow_interval));
        harvest = new Berry();
        seedtype = new BerrySeed();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
