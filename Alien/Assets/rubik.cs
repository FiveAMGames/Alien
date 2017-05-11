using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rubik : MonoBehaviour {

	public GameObject RightHand;
	public GameObject MatthewHand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		if (!RightHand.GetComponentInParent<Animator> ().GetBool ("LeftHand") && !RightHand.GetComponentInParent<Animator> ().GetBool ("RightHand")) {
			transform.position = RightHand.transform.position;
			transform.rotation = RightHand.transform.rotation;
			transform.SetParent (RightHand.transform);
			RightHand.GetComponentInParent<AnimationCharacter> ().Rubik ();
			GetComponentInChildren<Animator> ().SetBool ("Mess", true);
			GetComponent<Rigidbody> ().isKinematic = true;
		}
	}
	/*public void Messed(){
		transform.parent = null;
		GetComponent<Rigidbody> ().isKinematic = false;
	}*/

	public void Matthew(){
		GetComponentInChildren<Animator> ().SetBool ("Mess", false);
		transform.position =MatthewHand.transform.position;
		transform.rotation = MatthewHand.transform.rotation;
		transform.SetParent (MatthewHand.transform);
		GetComponentInChildren<Animator> ().SetBool ("InMatthew", true);

	}
	public void Drop(){
		GetComponentInChildren<Animator> ().SetBool ("InMatthew", false);
		transform.parent = null;
		transform.position = new Vector3 (transform.position.x, transform.position.y - 1f, transform.position.z);
		GetComponent<Rigidbody> ().isKinematic = false;

	}

}
