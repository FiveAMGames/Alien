using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFoodTriggerScript : MonoBehaviour {
	public Transform bowlPlace;
	public GameObject cat;
	public GameObject animCat;
	public GameObject keyFlat;
	public GameObject keyTrigger;
	public GameObject bubbleHunger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider coll){
		if (coll.CompareTag ("CatFood")) {
			if (!coll.GetComponent<MyItem> ().inInventory) {
				coll.gameObject.transform.position = bowlPlace.position;
				coll.gameObject.transform.rotation = bowlPlace.rotation;
				cat.GetComponent<Animator> ().SetTrigger ("Go");
				animCat.GetComponent<Animator> ().SetBool ("Walk", true);
				keyFlat.GetComponent<BoxCollider> ().isTrigger = false;
				keyFlat.GetComponent<Rigidbody> ().isKinematic = false;
				keyTrigger.SetActive (true);
				Destroy (bubbleHunger);
			}
		}
	}
}
