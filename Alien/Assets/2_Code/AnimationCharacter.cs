using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour {

	Animator anim;
	MyInventory inventory;
	public bool inIdle = false;
	public bool inWalk = false;


	bool onTimer = false;

	float timer = 0f;


	public bool onWalking = false;
	// Use this for initialization
	void Start () {
		inventory = GameObject.Find ("Game").GetComponent<MyInventory> ();
		anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		

		if (inventory._inHand != null) {
			anim.SetBool ("RightHand", true);
		}
		if (inventory._inHand == null) {
			anim.SetBool ("RightHand", false);
		}
		if (inventory._inMatthew != null) {
			anim.SetBool ("LeftHand", true);
		}
		if (!inventory._inMatthew == null) {
			anim.SetBool ("LeftHand", false);
		}





		
			
		if (onWalking) {
			Walk ();
		}
		if (!onWalking){
			Idle();			
		}
			

	}

	public void Jump(){
		GetComponentInParent<SoundScript> ().PlayJump();   //jump sound
	}




	public void Idle(){
		

		if (!inIdle) {
			inWalk = false;
			inIdle = true;

			anim.SetBool ("WalkTwo", false);
			anim.SetBool ("JumpOneLeg", false);

			if (inventory._inLeg == null) {
			
				anim.SetBool ("IdleTwoLegs", true);
			} else {
				anim.SetBool ("IdleOnOneLeg", true);
			}

		}


	}

	public void Walk(){

		if (!inWalk) {
			inIdle = false;
			inWalk = true;

			anim.SetBool ("IdleTwoLegs", false);
			anim.SetBool ("IdleOnOneLeg", false);

			if (inventory._inLeg == null) {
				anim.SetBool ("WalkTwo", true);
			} else {
				anim.SetBool ("JumpOneLeg", true);
			}

		}

	}

	public void Rubik(){
		anim.SetBool ("RubikMess", true);
		inventory.canTakeRightHand = false;
		inventory.canTakeMatthew = false;
	}

	public void RubikByMatthew(){
		anim.SetBool ("RubikMatthew", true);
		GetComponentInChildren<rubik> ().Matthew ();
		inventory.canTakeRightHand = true;


	}

	public void RubikMatthewEnd(){
		anim.SetBool ("RubikMatthew", false);
		GetComponentInChildren<rubik> ().Drop ();
		inventory.canTakeMatthew = true;
	}
		
}
