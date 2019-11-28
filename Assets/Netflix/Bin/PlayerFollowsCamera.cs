using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowsCamera : MonoBehaviour {

	public GameObject target;

	private void Update() {
		transform.rotation = target.transform.localRotation;
	}
}
