using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyTriggerFood : MonoBehaviour {

	public GameObject babyAnim;
	public Transform bowlPlace;
	public GameObject bubbleFoodWish;
	public GameObject lollipop;
	public Transform lollipopDropPlace;
	public GameObject newTriggerMatthew;

	public GameObject babyLollipopBubble;
	public GameObject LollipopBowlTrigger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider coll){
		if (coll.CompareTag ("CatFood")) {
			if (!coll.GetComponent<MyItem> ().inInventory) {
				coll.gameObject.transform.position = bowlPlace.position;
				coll.gameObject.transform.rotation = bowlPlace.rotation;
				GetComponentInParent<Animator> ().SetTrigger ("CatFood");
				GetComponentInParent<babyLollipopScript> ().lollipopByBaby = false;

				Destroy (babyLollipopBubble);
				LollipopBowlTrigger.SetActive (true);

				lollipop.transform.SetParent (null);

				lollipop.transform.position =lollipopDropPlace.position;

				//lollipop.GetComponent<Rigidbody> ().interpolation = RigidbodyInterpolation.None;
				//Slollipop.GetComponent<Collider> ().isTrigger = true;
				newTriggerMatthew.GetComponent<Collider> ().enabled = true;

				Destroy (bubbleFoodWish);
				Destroy (gameObject);
			}
		}
	}
}
