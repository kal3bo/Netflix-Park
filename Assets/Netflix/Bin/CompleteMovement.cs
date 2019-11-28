using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteMovement : MonoBehaviour {
	public float speed = 10.0f;
	public GameObject target;

    void Update() {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float forwardTranslation = Input.GetAxis("Horizontal") * speed;
        float sideTranslation = Input.GetAxis("Vertical") * -speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        forwardTranslation *= Time.deltaTime;
        sideTranslation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, forwardTranslation);
		transform.Translate(sideTranslation, 0, 0);

		// Keeps the camera inside the player structure
		transform.rotation = target.transform.localRotation;
    }
}
