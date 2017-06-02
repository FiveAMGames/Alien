using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rubikBack : MonoBehaviour {

	public Transform magicPlace;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider coll){
		if (coll.name == "keyFlat" || coll.name == "Rubik" || coll.name == "ropeGameObject") {
			coll.transform.position = magicPlace.transform.position;
		}
	}
}
