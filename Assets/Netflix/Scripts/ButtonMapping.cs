using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMapping : MonoBehaviour {
	Text myText;

	private void Start() 
	{
		myText = gameObject.GetComponent<Text>();
	}

	void Update () 
	{
		 foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
             if(Input.GetKey(vKey)){
				 myText.text = "Key: " + vKey;
             }
         }
		 if(Input.GetAxis("Horizontal") == 1){
			//Debug.Log("Axis");
		 }
	}

}
