using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
	public GameObject _panel;
	private bool _isMenuOn = false;
	

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.M)){
			if(!_isMenuOn){
				_panel.transform.gameObject.SetActive(true);
				_isMenuOn = true;
			}
			else{
				_panel.transform.gameObject.SetActive(false);
				_isMenuOn = false;
			}
			
		} 
	}
}
