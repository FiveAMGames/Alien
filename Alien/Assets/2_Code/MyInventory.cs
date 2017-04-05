﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInventory : MonoBehaviour {

	public Transform hand;
	public Transform leg;
	public Transform matthew;

	public MyItem _inHand;
	public MyItem _inLeg;
	public GameObject _inMatthew;


	public GameObject takeBolloon;
	public GameObject takeMatthew;

	float timer = 0f;

	void Start () {
		


	}
	

	void Update () {




		if (_inHand) {
			//print ("I have no free hands!");
			//GameObject.Find ("Player").GetComponentInChildren<AnimationCharacter> ().RightHandUp();
		}
		else if (_inMatthew) {
			//GameObject.Find ("Player").GetComponentInChildren<AnimationCharacter> ().LeftHandUp();
		}



	}

	public void addItem (MyItem item){
		Debug.Log ("Adding an Item in MY Inventory");
		if (!CanTakeItem ()) {
			
			Debug.Log ("I have no place enymore!");
		} else {
			GameObject.Find ("Player").GetComponent<SoundScript> ().PlayTakeItemFromWorld ();
			takeBolloon.SetActive (true);
			if (_inHand == null) {
				_inHand = item;
				item.transform.parent = hand;
				item.transform.position = hand.position;
				item.inInventory = true;

				Debug.Log ("Parenting to hand");
			} else {
				_inLeg = item;
				item.transform.parent = leg;
				item.transform.position = leg.position;
				item.inInventory = true;
				Debug.Log ("In leg");


				//GameObject.Find ("Player").GetComponentInChildren<AnimationCharacter> ().inIdle = false;
				//GameObject.Find ("Player").GetComponentInChildren<AnimationCharacter> ().inWalk = false;
				//GameObject.Find ("Player").GetComponentInChildren<AnimationCharacter> ().Idle ();

				//GameObject.Find ("Player").GetComponent<PlayerMovement> ().moveable = false;



				if (GameObject.Find ("Player").GetComponentInChildren<AnimationCharacter> ().inIdle) {
					GameObject.Find ("Player").GetComponentInChildren<Animator> ().SetBool ("IdleTwoLegs", false);
					GameObject.Find ("Player").GetComponentInChildren<Animator> ().SetBool ("IdleOnOneLeg", true);
				} else {
					GameObject.Find ("Player").GetComponentInChildren<Animator> ().SetBool ("WalkTwo", false);
					GameObject.Find ("Player").GetComponentInChildren<Animator> ().SetBool ("JumpOneLeg", true);
				}
			
			
			}
		}
	}

	public void removeItem(MyItem item){
		if (item == _inHand) {
			_inHand = null;
		} else if (item == _inLeg) {
			_inLeg = null;
			GameObject.Find ("Player").GetComponentInChildren<Animator> ().SetBool ("IdleOnOneLeg", false);
			if (GameObject.Find ("Player").GetComponentInChildren<AnimationCharacter> ().inIdle == true) {
				GameObject.Find ("Player").GetComponentInChildren<Animator> ().SetBool ("IdleTwoLegs", true);
			} else {
				GameObject.Find ("Player").GetComponentInChildren<Animator> ().SetBool ("WalkTwo", true);
			}

		}
		item.inInventory = false;
	}

	public bool hasItemInInventory(MyItem item){
		return (item == _inHand || item == _inLeg);
	}

	public bool CanTakeItem (){
		return (_inHand == null || _inLeg == null);
	}

	public MyItem getItemInHand()
	{
		
		if (_inHand.onDragging == true) {
			return _inHand;
		} else {
			return _inLeg;
		}

	}

	public void backInHand(MyItem item){
		if (item == _inHand) {
			item.transform.parent = hand;
			item.transform.position = hand.position;
		} else {
			item.transform.parent = leg;
			item.transform.position = leg.position;
		}
	}

	public void MatthewAddItem(GameObject item){
		if (!MatthewCanTakeItem ()) {
			
			Debug.Log ("Matthew has no place for a new item");
		} else {
			takeMatthew.SetActive (true);  //bubble

			item.transform.parent = matthew;
			item.GetComponent<Collider> ().isTrigger = true;
			item.transform.position = matthew.position;
			//item.transform.rotation = Quaternion.identity;
			Debug.Log ("Matthew has " + item.name);
			_inMatthew = item;
		}
	}

	public bool MatthewCanTakeItem(){
		return _inMatthew == null;
	}

}
