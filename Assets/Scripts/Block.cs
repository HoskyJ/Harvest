 using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;

 
 public class Block : MonoBehaviour
{
	GridManager gridInstance;
	Color materialColor;
	public Vector3 originalPos;
	public int tileWidth;
	public int tileDepth;

	void Awake() {
		materialColor = GetComponent<Renderer>().material.color;
		gridInstance = GameObject.Find("GridManager").GetComponent<GridManager>();
	}
	
	public void OnMouseDrag() {
		gridInstance.SnapToGrid(this.gameObject);
		if(!gridInstance.isPlaceable(this)){
				if(transform.position != originalPos){ //Prevents red highlight when returning to original pos while relocating.
					ChangeMaterialColor("red");
				}
			}
			else{
				ChangeMaterialColor("normal");
			}
	}

	public void ChangeMaterialColor(string color){
		if(color == "red"){
			GetComponent<Renderer>().material.color = Color.red;
		}
		else{
			GetComponent<Renderer>().material.color = materialColor;
		}
	}

	void OnMouseUp()
    {
		if(gridInstance.isPlaceable(this)){
			gridInstance.RemoveFromGrid(this);
			gridInstance.AddToGrid(this);
			originalPos = transform.position;
		}
		else{
			if(transform.position == originalPos){
				//Debug.Log("Returned block to original position");
			}
			else{
				//Debug.Log("CANNOT PLACE HERE!");
			}
			
			transform.position = originalPos;
			ChangeMaterialColor("normal");
		}
	}

	public List<Vector3> GetPosition(){
		List<Vector3> positions = new List<Vector3>();
		Vector3 centerPos = transform.position;

		float xStartPos = centerPos.x -(tileWidth/2 * gridInstance.tileSize/2);
		float zStartPos = centerPos.z -(tileDepth/2 * gridInstance.tileSize/2);

		for(float x = 0; x < tileWidth; x++){
			for(float z = 0; z < tileDepth; z++){
				positions.Add(new Vector3((xStartPos + (gridInstance.tileSize * x)), centerPos.y, (zStartPos + (gridInstance.tileSize * z))));
			}
		}
		return positions;
	}
}