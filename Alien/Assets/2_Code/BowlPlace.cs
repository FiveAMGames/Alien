﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlPlace : MonoBehaviour {

	public bool placeIsOccupied = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.childCount > 0) {
			placeIsOccupied = true;
		} else
			placeIsOccupied = false;
	}
}
