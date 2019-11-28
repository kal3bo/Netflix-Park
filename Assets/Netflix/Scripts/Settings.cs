using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {
	// Player preferences that can change in settings inside game
	public Text _speedText;
	private int _speed = 5;
	public Movement _movement;
	

	void Awake () {
		PlayerPrefs.SetInt("Speed", _speed);
		PlayerPrefs.SetString("Controller", "VRBox");
		_speedText.text = _speed.ToString();
	}

	public void IncreaseSpeed(){
		PlayerPrefs.SetInt("Speed", PlayerPrefs.GetInt("Speed") + 1);
		_movement.UpdateSettings();
		_speed++;
		_speedText.text = _speed.ToString();
	}
	
	public void DecreaseSpeed(){
		PlayerPrefs.SetInt("Speed", PlayerPrefs.GetInt("Speed") - 1);
		_movement.UpdateSettings();
		_speed--;
		_speedText.text = _speed.ToString();
	}

	public void SetController(string s){
		PlayerPrefs.SetString("Controller", s);
		_movement.UpdateSettings();
	}
}