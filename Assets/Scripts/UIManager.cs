using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public GameObject blockMenu;
	public GameObject plantMenu;

	void Start () {
		
	}
	
	public void ShowMenu(string menu){
		if(menu == "blockMenu"){
			blockMenu.SetActive(true);
			plantMenu.SetActive(false);
		}
		else if (menu == "plantMenu"){
			blockMenu.SetActive(false);
			plantMenu.SetActive(true);
			
		}
	}
}
