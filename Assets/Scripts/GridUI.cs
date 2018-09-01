using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUI : MonoBehaviour {
	GridManager gridInstance;
	public GameObject gridTile;
	private void Awake() {
		/* gridInstance = GameObject.Find("GridManager").GetComponent<GridManager>();
		float width = gridInstance.xSize * gridInstance.tileSize;
		float height= gridInstance.zSize * gridInstance.tileSize;
		GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
		GetComponent<RectTransform>().transform.position = new Vector2(0, 0.35f);
		GameObject gridTileInstance = Instantiate(gridTile, new Vector3(0,0,0), Quaternion.Euler(-90,0,0));
		gridTileInstance.transform.SetParent(this.gameObject.transform);
		gridInstance.transform.position = new Vector3(0,0,0);
		/* for(int x = 0; x < gridInstance.xSize; x++){
			for(int z = 0; z < gridInstance.zSize; z++){
				
				
			}
		} */
	}
}
