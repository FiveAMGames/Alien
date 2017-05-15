using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeButton : MonoBehaviour {

	public Transform placeForBowl;
	public GameObject catFoodPrefab;
	private int count = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		float dist = Vector3.Distance (GameObject.Find ("Player").transform.position, transform.position);
		if (dist < 3f) {
			
			if (!placeForBowl.GetComponent<BowlPlace> ().placeIsOccupied) {
				Instantiate (catFoodPrefab, placeForBowl);


			}


		}
	}
}
