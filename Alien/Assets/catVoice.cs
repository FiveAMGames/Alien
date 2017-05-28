using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catVoice : MonoBehaviour {

	private bool check = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		float dist = Vector3.Distance (GameObject.Find ("Player").transform.position, transform.position);
		print ("CatVoiceCheck");
		if (!GetComponent<MyItem> ().matthewProperty && dist < 3f && !check) {
			Camera.main.GetComponent<VoiceOverScript> ().CatForBuisness ();
			check = true;
		}
	}
}
