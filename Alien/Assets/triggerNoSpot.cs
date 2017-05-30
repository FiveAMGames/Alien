using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerNoSpot : MonoBehaviour {

	public GameObject loudspeaker;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider coll){
		if (coll.CompareTag ("Player")) {
			loudspeaker.GetComponent<Animator>().SetBool("Speak", true);
			Cursor.lockState = CursorLockMode.Locked;
			Camera.main.GetComponent<CameraScript> ().cutScene = true;
			coll.GetComponent<PlayerMovement> ().moveable = false;
			Camera.main.GetComponent<VoiceOverScript> ().IAmLate ();
			StartCoroutine (waitUntilHeSpeaks ());
		}
	}
	IEnumerator waitUntilHeSpeaks(){
		yield return new WaitForSecondsRealtime (10f);
		Camera.main.GetComponent<CameraScript> ().fromCutScene = true;
		GameObject.Find("Player").GetComponent<PlayerMovement> ().moveable = true;
		loudspeaker.GetComponent<Animator>().SetBool("Speak", false);
		Cursor.lockState = CursorLockMode.None;
		Destroy (gameObject);
	}
}
