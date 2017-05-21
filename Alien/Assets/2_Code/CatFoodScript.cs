using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFoodScript : MonoBehaviour {
	
	private float dist;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		dist = Vector3.Distance (GameObject.Find ("Player").transform.position, transform.position);

	}
	void OnMouseDown ()
	{
		
			if (dist < 2f) {
				
			if (!GameObject.Find ("Rubik").GetComponent<rubik> ().GetComponentInChildren<Animator> ().GetBool ("InMatthew") && !GameObject.Find ("Rubik").GetComponent<rubik> ().GetComponentInChildren<Animator> ().GetBool ("Mess")) {
					
				GameObject.Find ("BaloonSystem").SendMessage ("CatFoodBaloon");
				Destroy (gameObject);

			} else {
				if (GameObject.Find ("Rubik").GetComponent<rubik> ().GetComponentInChildren<Animator> ().GetBool ("InMatthew")) {
					GetComponent<MyItem> ().matthewProperty = false;
					Destroy (this);
				}
			}
		}
	}
}
