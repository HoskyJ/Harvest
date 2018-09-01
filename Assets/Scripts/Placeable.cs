using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Placeable : MonoBehaviour, IDragHandler, IEndDragHandler{

	public GameObject blockPrefab;
	public GameObject UIItem;
	GridManager gridInstance;
	GameObject blockInstance;
	GameObject iconInstance;
	bool iconInstanceSpawned;
	bool blockInstanceSpawned;
	Block block;

	// Use this for initialization
	void Start () {
		gridInstance = GameObject.Find("GridManager").GetComponent<GridManager>();
	}

    public void OnDrag(PointerEventData eventData)
    {
        RectTransform invPanel = transform.parent as RectTransform;

		if(RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition)){
			if(blockInstanceSpawned){
				Destroy(blockInstance);
				blockInstanceSpawned = false;
			}
			else{
				if(!iconInstanceSpawned){
					iconInstance = Instantiate(UIItem);
					iconInstance.transform.SetParent(this.transform);
					iconInstance.GetComponent<Image>().sprite = this.GetComponent<Image>().sprite;
					iconInstanceSpawned = true;
				}
				iconInstance.transform.position = Input.mousePosition;
			}
		}
		else{
			if(!blockInstanceSpawned){
				Destroy(iconInstance);
				iconInstanceSpawned = false;
				blockInstance= Instantiate(blockPrefab);
				block = blockInstance.GetComponent<Block>();
				blockInstanceSpawned = true;
			}
			
			gridInstance.SnapToGrid(blockInstance);
			if(!gridInstance.isPlaceable(block)){
				block.ChangeMaterialColor("red");
			}
			else{
				block.ChangeMaterialColor("normal");
			}
		}
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(iconInstance);
		iconInstanceSpawned = false;
		blockInstanceSpawned = false;

		if(gridInstance.isPlaceable(block)){
			gridInstance.AddToGrid(block);
			block.originalPos = blockInstance.transform.position;
		}
		else{
			Debug.Log("CANNOT PLACE HERE!");
			Destroy(blockInstance);
		}
    }
}
