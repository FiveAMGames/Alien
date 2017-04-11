using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfSprites : MonoBehaviour {

	float startAlpha = 1f;
	float endAlpha = 0.5f;

	GameObject[] children;
	// Use this for initialization
	void Start () {
		children = GetComponentsInChildren<GameObject> ();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChildrenOpacity(){
		
	}


}
