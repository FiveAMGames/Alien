using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockerScript : MonoBehaviour {
	public GameObject alienInBed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AnimationEnd(){
		alienInBed.GetComponent<Animator> ().SetTrigger ("Freedom");
	}
}
