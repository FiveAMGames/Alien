using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlavierTrigger : MonoBehaviour {
	private MyInventory inventory;
	public Transform klavierPlace;
	public Transform placeToDrop;

	public AudioClip[] clips;
	private int rand;  //random
	public GameObject bubblePiano;
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
				coll.GetComponentInChildren<Animator> ().SetBool ("Klavier", true);


				coll.gameObject.transform.position = klavierPlace.position;
				coll.gameObject.transform.rotation = klavierPlace.rotation;

				bubblePiano.SetActive (true);

				rand = Random.Range (1, clips.Length);

					
				 


				GetComponent<AudioSource> ().clip = clips [rand];
				//Camera.main.GetComponent<VoiceOverScript> ().MatthewPlaysSoWell ();
				GetComponent<AudioSource> ().PlayDelayed (0.5f);

				if (inventory._inMatthew != null) {
					inventory._inMatthew.transform.position = placeToDrop.position;

					inventory._inMatthew.GetComponent<Rigidbody> ().drag = 2f;
					inventory._inMatthew.GetComponent<Rigidbody> ().velocity = new Vector3(0, 0, 0);
					inventory.removeItemMatthew ();

				}
			}
		}
	}

}
