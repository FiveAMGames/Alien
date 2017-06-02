using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatthewTrigger : MonoBehaviour {

	public MyInventory inventory;
	 
	public GameObject relatedObject;
	public bool keyFlat = false;

	void Start () {
		inventory = GameObject.Find ("Game").GetComponent<MyInventory>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerStay(Collider coll){
		if (coll.CompareTag ("Player")) {
			

			if (inventory.canTakeMatthew) {
				inventory.MatthewAddItem (relatedObject);
				coll.GetComponent<SoundScript> ().PlayMatthewTake ();
				if (keyFlat) {
					Camera.main.GetComponent<VoiceOverScript> ().MatthewTakesKey ();
				}
				Destroy (gameObject);
			}
		}
	}

}
