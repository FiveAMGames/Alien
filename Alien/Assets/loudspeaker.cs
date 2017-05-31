using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loudspeaker : MonoBehaviour {


	public GameObject TheEndTest;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		float dist = Vector3.Distance (GameObject.Find ("Player").transform.position, transform.position);
		if (dist < 4f) {
			GetComponent<Animator> ().SetBool ("Speak", true);
			TheEndTest.GetComponent<Animator> ().SetBool ("Open", true);
			StartCoroutine (waitToBubble ());
		}
	}
	IEnumerator waitToBubble(){
		yield return new WaitForSeconds (6f);
		GetComponent<Animator> ().SetBool ("Speak", false);
	}

}
