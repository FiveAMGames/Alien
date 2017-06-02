using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bollardScript : MonoBehaviour {
	public GameObject rope;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Interaction(){
		rope.SetActive (true);
		GameObject.Find ("Cursor").GetComponent<CursorTextures> ().NormalCurs ();
	}
}
