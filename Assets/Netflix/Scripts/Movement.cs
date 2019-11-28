using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Public variables: 
	public float _speed;
	public string _controller;
	public GameObject _head;
	public AudioSource _walkingSound;
	private float forwardTranslation = 0;
	private float sideTranslation = 0;

	// Initializing with the default settings or the one saved by the user:
	private void Start() {
		_walkingSound = GetComponent<AudioSource>();
		_speed = PlayerPrefs.GetInt("Speed");
		_controller = PlayerPrefs.GetString("Controller");
	}

	// When the user changes something about settings the next method will update the variables within the movement script
	public void UpdateSettings() {
		_speed = PlayerPrefs.GetInt("Speed");
		_controller = PlayerPrefs.GetString("Controller");
	}

    void Update() {
		// Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1.
		// The direction of movement depends in which controller the user is working on:
		
		// When the user is playing with the VRBox controller:
		if (string.Equals(_controller, "VRBox")){
			forwardTranslation = Input.GetAxis("Horizontal") * _speed;
			sideTranslation = Input.GetAxis("Vertical") * _speed;
		}
		// When the user is playing with any videogame controller:
		else if (string.Equals(_controller, "Videogame")){
			forwardTranslation = Input.GetAxis("Vertical") * -_speed;
			sideTranslation = Input.GetAxis("Horizontal") * _speed;	
		}
		else{
			Debug.Log("Error in controller selection");
		}
       
	   // Sound feedback:
		if((forwardTranslation != 0 || sideTranslation != 0) && _walkingSound.isPlaying == false){
			_walkingSound.Play();
		}

        // Make it move X meters per second instead of X meters per frame...
        forwardTranslation *= -Time.deltaTime;
		sideTranslation *= Time.deltaTime;

		// Calculates the direction to which it moves:
		if (Mathf.RoundToInt(_head.transform.eulerAngles.y) == 0){
			transform.Translate(0, 0, forwardTranslation);
			transform.Translate(sideTranslation, 0, 0);
			//Debug.Log("0");			// Test Purposes
		}
		else if (_head.transform.eulerAngles.y < 90){
			transform.Translate((forwardTranslation/90) * _head.transform.eulerAngles.y, 0, (forwardTranslation/90) * (90 - _head.transform.eulerAngles.y));
			transform.Translate((sideTranslation/90) * (180 - (_head.transform.eulerAngles.y + 90)), 0, (-sideTranslation/90) * ((_head.transform.eulerAngles.y + 90) - 90));
			//Debug.Log("< 90");		// Test Purposes
		}
		else if (Mathf.RoundToInt(_head.transform.eulerAngles.y) == 90){
			transform.Translate(forwardTranslation, 0, 0);
			transform.Translate(0, 0, -sideTranslation);
			//Debug.Log("90");			// Test Purposes
		}
		else if (_head.transform.eulerAngles.y < 180){
			transform.Translate((forwardTranslation/90) * (180 - _head.transform.eulerAngles.y), 0, (-forwardTranslation/90) * (_head.transform.eulerAngles.y - 90));
			transform.Translate((-sideTranslation/90) * ((_head.transform.eulerAngles.y + 90) -180), 0, (-sideTranslation/90) * (270 - (_head.transform.eulerAngles.y + 90)));
			//Debug.Log("< 180");		// Test Purposes
		}
		else if (Mathf.RoundToInt(_head.transform.eulerAngles.y) == 180){
			transform.Translate(0, 0, -forwardTranslation);
			transform.Translate(-sideTranslation, 0, 0);
			//Debug.Log("180");			// Test Purposes
		}
		else if (_head.transform.eulerAngles.y < 270){
			transform.Translate((-forwardTranslation/90) * (_head.transform.eulerAngles.y - 180), 0, (-forwardTranslation/90) * (270 - _head.transform.eulerAngles.y));
			transform.Translate((-sideTranslation/90) * (360 - (_head.transform.eulerAngles.y + 90)), 0, (sideTranslation/90) * ((_head.transform.eulerAngles.y + 90) - 270));
			//Debug.Log("< 270");		// Test Purposes
		}
		else if (Mathf.RoundToInt(_head.transform.eulerAngles.y) == 270){
			transform.Translate(-forwardTranslation, 0, 0);
			transform.Translate(0, 0, sideTranslation);
			//Debug.Log("270");			// Test Purposes
		}
		else {
			transform.Translate((-forwardTranslation/90) * (360 - _head.transform.eulerAngles.y), 0, (forwardTranslation/90) * (_head.transform.eulerAngles.y - 270));
			transform.Translate((sideTranslation/90) * (_head.transform.eulerAngles.y + 90 - 360), 0, (sideTranslation/90) * (90 - (_head.transform.eulerAngles.y + 90 - 360)));
			//Debug.Log("< 360");		// Test Purposes
		}
    }
}