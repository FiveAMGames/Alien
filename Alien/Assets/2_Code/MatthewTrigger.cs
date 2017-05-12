using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatthewTrigger : MonoBehaviour {

	public MyInventory inventory;
	 
	public GameObject relatedObject;


	void Start () {
		inventory = GameObject.Find ("Game").GetComponent<MyInventory>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider coll){
		if (coll.CompareTag ("Player")) {
			
			inventory.MatthewAddItem (relatedObject);
			if (inventory.canTakeMatthew) {
				coll.GetComponent<SoundScript> ().PlayMatthewTake ();
				Destroy (gameObject);
			}
		}
	}

}
