using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Plantable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	Sprite cropIcon;
	GameObject UIItem;
	GameObject cropIconInstance;

    public void OnBeginDrag(PointerEventData eventData)
    {
        cropIconInstance = Instantiate(UIItem);
		cropIconInstance.transform.SetParent(this.transform);
		cropIconInstance.GetComponent<Image>().sprite = cropIcon;
    }

    public void OnDrag(PointerEventData eventData)
    {
        cropIconInstance.transform.position = Input.mousePosition;
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			GameObject tileHit = hit.collider.gameObject;
			Block block = tileHit.GetComponent<Block>();
			if (block.GetType() == typeof(CropBlock) && tileHit.GetComponent<Crop>() == null)
			{
				tileHit.AddComponent<Wheat>();
			}
		}
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(cropIconInstance);
    }

    void Awake () {
		cropIcon = GetComponent<Image>().sprite;
		UIItem = Resources.Load("Prefabs/UI/UIItem") as GameObject;
	}
	

	// Update is called once per frame
	void Update () {
		
	}
}
