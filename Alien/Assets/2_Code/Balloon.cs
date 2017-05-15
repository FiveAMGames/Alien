using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

	public float time = 4f;
	private float timer = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;
		//Debug.Log (timer);


			

			if (timer > time) {
				timer = 0f;
				gameObject.SetActive (false);


		}



	}
}
