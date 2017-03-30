using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {


	private float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer++;
		//Debug.Log (timer);
		if (gameObject.name != "matthewTakeSomething") {
			if (timer > 45f) {
				timer = 0f;
				gameObject.SetActive (false);

			}
		} else {
			if (timer > 100f) {
				timer = 0f;
				gameObject.SetActive (false);

			}
		}



	}
}
