using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babyLollipopScript : MonoBehaviour {
	public bool lollipopByBaby = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){
		if (coll.CompareTag ("Player") && lollipopByBaby) {
			GetComponent<Animator> ().SetTrigger ("Matthew");
			GameObject.Find ("BaloonSystem").GetComponent<BaloonSystem> ().MatthewLollipop ();
		}
	}
}
