using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 10.0f;
	public GameObject _head;

    void Update() {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Horizontal") * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;

		// Calculate the direction to which it moves:
		if (Mathf.RoundToInt(_head.transform.eulerAngles.y) == 0){
			transform.Translate(0, 0, translation);
			Debug.Log("0");
		}
		else if (_head.transform.eulerAngles.y < 90){
			transform.Translate((translation * Mathf.Cos(90 - _head.transform.eulerAngles.y)), 0, (translation * Mathf.Sin(90 - _head.transform.eulerAngles.y)));
			Debug.Log("<90");
		}
		else if (Mathf.RoundToInt(_head.transform.eulerAngles.y) == 90){
			transform.Translate(translation, 0, 0);
			Debug.Log("90");
		}
		else if (_head.transform.eulerAngles.y < 180){
			transform.Translate((translation * Mathf.Sin(180 - _head.transform.eulerAngles.y)), 0, (-translation * Mathf.Cos(180 - _head.transform.eulerAngles.y)));
			Debug.Log("<180");
		}
		else if (Mathf.RoundToInt(_head.transform.eulerAngles.y) == 180){
			transform.Translate(0, 0, -translation);
			Debug.Log("180");
		}
		else if (_head.transform.eulerAngles.y < 270){
			transform.Translate(-translation * Mathf.Cos(270 - _head.transform.eulerAngles.y), 0, -translation * Mathf.Sin(270 - _head.transform.eulerAngles.y));
			Debug.Log("<270");
		}
		else if (Mathf.RoundToInt(_head.transform.eulerAngles.y) == 270){
			transform.Translate(-translation, 0, 0);
			Debug.Log("270");
		}
		else {
			transform.Translate(-translation * Mathf.Sin(360 - _head.transform.eulerAngles.y), 0, translation * Mathf.Cos(360 - _head.transform.eulerAngles.y));
			Debug.Log("<360");
		}
    }
}
