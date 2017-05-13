using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienInBed : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void KeyInHand(){
		print (" I seee you");
		GetComponent<Animator> ().SetBool ("Key", true);
	
	}


}
