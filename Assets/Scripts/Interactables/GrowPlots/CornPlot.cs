using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornPlot : GrowingPlot {

	// Use this for initialization
	void Start () {
        object_name = "Cornfield";
        StartCoroutine(GrowDelay(grow_interval));
        harvest = new Corn();
        seedtype = new CornSeed();
	}
}
