using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rubik : MonoBehaviour {

	public GameObject RightHand;
	public GameObject MatthewHand;
	public bool rubikOn = false;
	private Vector3 originalScale;
	private bool noVoiceAnemore = false;
	// Use this for initialization
	void Start () {
		originalScale = transform.lossyScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		if (!RightHand.GetComponentInParent<Animator> ().GetBool ("LeftHand") && !RightHand.GetComponentInParent<Animator> ().GetBool ("RightHand") && !RightHand.GetComponentInParent<Animator> ().GetBool ("Klavier")) {
			float dist = Vector3.Distance (GameObject.Find ("Player").transform.position, transform.position);
			if (dist < 2f && !noVoiceAnemore) {
				rubikOn = false;
				Camera.main.GetComponent<VoiceOverScript> ().UnsolvedRubik ();
				transform.position = RightHand.transform.position;
				transform.rotation = RightHand.transform.rotation;
				transform.SetParent (RightHand.transform);
				RightHand.GetComponentInParent<AnimationCharacter> ().Rubik ();
				GetComponentInChildren<Animator> ().SetBool ("Mess", true);
				GetComponent<Rigidbody> ().isKinematic = true;
				GameObject.Find ("Game").GetComponent<MyInventory> ().stopTaking = true;
				noVoiceAnemore = true;

			}
		}
	}
	/*public void Messed(){
		transform.parent = null;
		GetComponent<Rigidbody> ().isKinematic = false;
	}*/

	public void Matthew(){
		rubikOn = true;
		GetComponentInChildren<Animator> ().SetBool ("Mess", false);
		transform.position =MatthewHand.transform.position;
		//transform.rotation = MatthewHand.transform.rotation;
		transform.SetParent (MatthewHand.transform);
		GetComponentInChildren<Animator> ().SetBool ("InMatthew", true);
		GameObject.Find ("Game").GetComponent<MyInventory> ().stopTaking = false;


	}
	public void Drop(){
		rubikOn = false;
		transform.parent = null;
		transform.position = new Vector3 (transform.position.x, transform.position.y - 1f, transform.position.z+1f);
		GetComponent<Rigidbody> ().isKinematic = false;

		GetComponentInChildren<Animator> ().SetBool ("InMatthew", false);
		transform.localScale = originalScale;
		noVoiceAnemore = false;
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.CompareTag ("Ground") || coll.gameObject.CompareTag ("Wall")) {
			GetComponent<AudioSource> ().Play ();
		}
	}

	void OnMouseOver(){
		float dist = Vector3.Distance (GameObject.Find ("Player").transform.position, transform.position);
		if (dist < 3f) {
			GameObject.Find ("Cursor").GetComponent<CursorTextures> ().ItemCurs ();
		}
	}
	void OnMouseExit(){
		float dist = Vector3.Distance (GameObject.Find ("Player").transform.position, transform.position);
		if (dist < 3f) {
			GameObject.Find ("Cursor").GetComponent<CursorTextures> ().NormalCurs ();
		}
	}
}
