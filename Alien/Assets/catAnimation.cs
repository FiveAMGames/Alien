using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catAnimation : MonoBehaviour {

	public GameObject bubbleLollipop; 
	public GameObject catAnim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StopWalkAnimation(){
		catAnim.GetComponent<Animator> ().SetBool ("Walk", false);
		GetComponent<Animator> ().enabled = false;
		GetComponent<MyItem> ().matthewProperty = false;
		bubbleLollipop.SetActive (true);
	}
}
