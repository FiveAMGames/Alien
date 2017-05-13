using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowScript : MonoBehaviour {
	public GameObject pillowAfter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		pillowAfter.SetActive (enabled);
		Destroy (gameObject);
	}
}
