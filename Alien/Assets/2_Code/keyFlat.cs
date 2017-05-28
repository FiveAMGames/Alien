using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyFlat : MonoBehaviour {
	public GameObject door;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void endKeyAnim(){
		
		door.GetComponent<Animator> ().SetTrigger ("Open");
	}



}
