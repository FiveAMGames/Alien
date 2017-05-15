using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whereToPlaceInHandForPrefab : MonoBehaviour {

	public string nameOfPlace;
	// Use this for initialization
	void Start () {
		GetComponent<MyItem> ().whereToParent = GameObject.Find (nameOfPlace).transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
