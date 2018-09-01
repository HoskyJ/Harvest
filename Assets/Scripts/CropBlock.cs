using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropBlock : Block {
	UIManager UIManagerInstance;

	private void Start() {
		UIManagerInstance = GameObject.Find("UIManager").GetComponent<UIManager>();
	}
	public void OnMouseDown() {
		UIManagerInstance.ShowMenu("plantMenu");
		Debug.Log("sex");
	}
}
