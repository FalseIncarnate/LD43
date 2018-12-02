using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CottonPlot : GrowingPlot {

	// Use this for initialization
	void Start () {
        object_name = "Cotton Field";
        StartCoroutine(GrowDelay(grow_interval));
        harvest = new Cotton();
        seedtype = new CottonSeed();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
