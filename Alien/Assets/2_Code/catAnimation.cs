using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catAnimation : MonoBehaviour {

	public GameObject bubbleLollipop; 
	public GameObject catAnim;
	public GameObject hammer;

	public Transform placeGreenAlien;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StopWalkAnimation(){
		catAnim.GetComponent<Animator> ().SetBool ("Walk", false);
		GetComponent<Animator> ().enabled = false;
		//GetComponent<MyItem> ().matthewProperty = false;
		bubbleLollipop.SetActive (true);
	}

	public void Go(){
		GameObject.Find("Game").GetComponent<MyInventory>().removeItem (GameObject.Find("Game").GetComponent<MyInventory>().getItemInHand ());
		GetComponent<Rigidbody> ().isKinematic = true;
		GetComponent<MyItem> ().matthewProperty = true;
		transform.position = placeGreenAlien.position;
		transform.rotation = placeGreenAlien.rotation;
		hammer.transform.parent = null;
		hammer.GetComponent<MyItem> ().matthewProperty = false;
		hammer.GetComponent<Rigidbody> ().isKinematic = false;
		hammer.GetComponent<Collider> ().isTrigger = false;
	}
}
