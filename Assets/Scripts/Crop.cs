using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour {

	protected GameObject[] growthStage;
	GameObject plantedCrop;
	Coroutine growth;
	protected float growthTime;
	float timeGrowing;
	bool isHarvestable;

	private void Awake() {
		timeGrowing = 0f;
	}
	private void Start() {
		plantedCrop.transform.parent = transform;
	}
	protected void Plant(){
		growth = StartCoroutine("IGrow");
	}
	IEnumerator IGrow()
    {
        while (timeGrowing <= growthTime)
        {
			if(timeGrowing == 0){
				plantedCrop = Instantiate(growthStage[0], transform.position, transform.rotation);
			}
            else if(timeGrowing == Mathf.RoundToInt(growthTime / 2f))
            {
				Debug.Log("22");
                Destroy(plantedCrop);
                plantedCrop = Instantiate(growthStage[1], transform.position, transform.rotation);
                plantedCrop.transform.parent = transform;
            }
            else if (timeGrowing == growthTime)
            {
                isHarvestable = true;
				Debug.Log("Crop ready for harvest");
                StopCoroutine(growth);
            }
            timeGrowing += 1f;
            yield return new WaitForSeconds(1);
        }
    }
}
