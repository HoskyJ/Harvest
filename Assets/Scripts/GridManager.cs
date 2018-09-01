using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GridManager : MonoBehaviour {
	float planeY = 0;
	Plane plane;
	public float tileSize = 1.46f / 2f;
	public float xSize = 6f;
	public float zSize = 6f;
	public GameObject tilePrefab;
	Dictionary<Vector3, Block> grid;

	// Use this for initialization
	void Start () {
		plane = new Plane(Vector3.up, Vector3.up * planeY); // ground plane
		grid = new Dictionary<Vector3, Block>();
		GenerateGrid();
	}
	
	void GenerateGrid(){
		float xStartPos = tileSize/2f * (xSize - 1);
		float zStartPos = tileSize/2f * (zSize - 1);
		
		for(int x = 0; x < xSize; x++){
			float xPos = xStartPos - (x * tileSize);
			for(int z = 0; z < zSize; z++){
				float zPos = zStartPos - (z * tileSize);
				Vector3 pos = new Vector3(xPos, planeY, zPos);
				grid.Add(pos, null);
				Instantiate(tilePrefab, pos, Quaternion.identity);
			}
		}
	}

	public bool isPlaceable(Block block){
		List<Vector3> locations = block.GetPosition();

		foreach(Vector3 pos in locations){
			if(!grid.ContainsKey(pos)){
				return false;
			}
			else{
				if(grid[pos] != null){
					if(grid[pos] != block){
						return false;
					}
				}
			}
		}
		return true;
	}

	public void AddToGrid(Block block){
		List<Vector3> locations = block.GetPosition();
		foreach(Vector3 pos in locations){
			grid[pos] = block;
		}
	}

	public void RemoveFromGrid(Block block){
		foreach(var item in grid.Where(kvp => kvp.Value == block).ToList())
		{
			grid[item.Key] = null;
		}
	}

	public void SnapToGrid(GameObject block){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float distance; // the distance from the ray origin to the ray intersection of the plane

		if(plane.Raycast(ray, out distance))
		{
			Vector3 position = ray.GetPoint(distance);
			position.x = Mathf.RoundToInt(position.x / tileSize) * tileSize;
			position.z = Mathf.RoundToInt(position.z / tileSize) * tileSize;

			if(block.GetComponent<Block>().tileWidth == 1){
				position.x -= tileSize/2f;
			}
			
			if(block.GetComponent<Block>().tileDepth == 1){
				position.z -= tileSize/2f;
			}

			block.transform.position = position; // distance along the ray
		}
	}
}
