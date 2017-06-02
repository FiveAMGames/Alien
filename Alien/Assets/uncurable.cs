using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uncurable : MonoBehaviour {

	private float dist;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (GameObject.Find ("Player").transform.position, transform.position);
	}
	void OnMouseDown(){
		if (dist < 4f) {
			Camera.main.GetComponent<VoiceOverScript> ().Uncurable ();
		}
	}
}
