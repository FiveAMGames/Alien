using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour {

	Animator anim;
	MyInventory inventory;
	public bool inIdle = false;
	public bool inWalk = false;
	public GameObject CameraVoiceOver;

	private float timer = 0f;
	private int matthewAnimClips = 0;

	bool onTimer = false;

	private float timerAnim = 0f;

	public AnimationClip[] matthewAnimations;
	public AnimatorOverrideController animatorOverrideController;

	public bool onWalking = false;
	// Use this for initialization
	void Start () {
		inventory = GameObject.Find ("Game").GetComponent<MyInventory> ();
		anim = GetComponentInChildren<Animator> ();

		//animatorOverrideController = new AnimatorOverrideController (anim.runtimeAnimatorController);
		anim.runtimeAnimatorController = animatorOverrideController;
	}
	
	// Update is called once per frame
	void Update () {
		
		timerAnim += Time.deltaTime;

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


	public void ChangeMatthew(){
		
	/*		print ("Change Matthew");
			//int rand = Random.Range (0, 4);
		if (matthewAnimClips < 3) {
			matthewAnimClips += 1;
				
			//print (rand);
		} else {
			matthewAnimClips = 0;
		}
		animatorOverrideController ["matthewWalkFree"] = matthewAnimations [matthewAnimClips];*/

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
	public void KlavierEnd(){
		GetComponentInParent<PlayerMovement> ().moveable = true;
		anim.SetBool ("Klavier", false);
	}
	public void Rope(){
		
		anim.SetBool ("rope", true);
	}
	public void RopeOut(){
		anim.SetBool ("rope", false);
	}


	public void StartLevel(){
		CameraVoiceOver.GetComponent<VoiceOverScript> ().StartLevel ();
	}
	public void Movable(){
		GetComponentInParent<PlayerMovement> ().moveable = true;
		CameraVoiceOver.GetComponent<CameraScript> ().startCamera = false;
		anim.SetTrigger ("IntroOut");
	}

	public void KlavierEndAnimation(){
		
	}
		



}
