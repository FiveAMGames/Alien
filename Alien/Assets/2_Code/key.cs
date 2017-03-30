using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour {

	public Transform hand;

	// Use this for initialization
	void Start () {
		hand = GameObject.Find ("InvHand").transform;
		transform.parent = hand;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
