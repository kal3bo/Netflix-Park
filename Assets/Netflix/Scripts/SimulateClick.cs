using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimulateClick : MonoBehaviour {

	
	[SerializeField] GameObject[] buttons;

	// Update is called once per frame
	void Update () {
		if(Input.inputString != ""){
			int buttonIndex;
			int.TryParse (Input.inputString, out buttonIndex);
			buttonIndex -= 1;
			if(buttonIndex >=0 && buttonIndex < buttons.Length){
				ExecuteEvents.Execute<IPointerClickHandler>(buttons[buttonIndex],new PointerEventData(EventSystem.current),ExecuteEvents.pointerClickHandler);
			}
		}
	}
}
