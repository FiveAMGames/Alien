using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class praesi : MonoBehaviour {

	//public GameObject playeanim;
	// Use this for initialization
	void Start () {
		GetComponent<Animator> ().SetTrigger ("Praesi");
		Camera.main.GetComponent<CameraScript> ().startCamera = false;
		GameObject.Find ("Player").GetComponent<PlayerMovement> ().moveable = true;
		GameObject.Find ("Cursor").GetComponent<CursorTextures> ().NormalCurs ();
		Cursor.lockState = CursorLockMode.None;
		GetComponent<Animator> ().SetTrigger ("IntroOut");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
