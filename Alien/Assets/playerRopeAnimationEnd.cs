using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRopeAnimationEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void DownEnd(){
		GetComponent<Animator> ().SetBool ("down", false);
	}
}
