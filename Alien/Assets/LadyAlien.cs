using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyAlien : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		float dist = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);
		if (dist < 4f) {
			Camera.main.GetComponent<VoiceOverScript> ().LadyCast ();

		}
	}

}
