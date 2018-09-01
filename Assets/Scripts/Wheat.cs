using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : Crop {

	void Awake () {
		growthStage = new GameObject[3];
		growthStage[0] = Resources.Load("Prefabs/Crops/WheatCrop1") as GameObject;
        growthStage[1] = Resources.Load("Prefabs/Crops/WheatCrop2") as GameObject;
		growthStage[2] = Resources.Load("Hay") as GameObject;
		growthTime = 5f;
	}
	
	private void Start() {
		Plant();
	}
}
