using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlavierTrigger : MonoBehaviour {
	private MyInventory inventory;
	public Transform klavierPlace;
	public Transform placeToDrop;
	// Use this for initialization
	void Start () {
		inventory = GameObject.Find ("Game").GetComponent<MyInventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.CompareTag ("Player")) {

			if (!GameObject.Find ("Rubik").GetComponent<rubik> ().GetComponentInChildren<Animator> ().GetBool ("InMatthew") && !GameObject.Find ("Rubik").GetComponent<rubik> ().GetComponentInChildren<Animator> ().GetBool ("Mess")) {


				coll.GetComponent<PlayerMovement> ().moveable = false;
				coll.GetComponentInChildren<Animator> ().SetBool ("WalkTwo", false);
				coll.GetComponentInChildren<Animator> ().SetBool ("IdleTwoLegs", true);
				coll.GetComponentInChildren<Animator> ().SetBool ("LeftHand", false);
				coll.GetComponentInChildren<Animator> ().SetTrigger ("Klavier");


				coll.gameObject.transform.position = klavierPlace.position;
				coll.gameObject.transform.rotation = klavierPlace.rotation;

				if (inventory._inMatthew != null) {
					inventory._inMatthew.transform.position = placeToDrop.position;
					inventory.removeItemMatthew ();
				}
			}
		}
	}
}
