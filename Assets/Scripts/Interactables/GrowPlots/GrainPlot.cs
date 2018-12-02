using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrainPlot : GrowingPlot {

	// Use this for initialization
	void Start () {
        object_name = "Grain Field";
        StartCoroutine(GrowDelay(grow_interval));
        harvest = new Grain();
        seedtype = new GrainSeed();
    }
}
