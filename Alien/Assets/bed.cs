using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour {

	public float distanceZ = 1.5f;
	public GameObject transpBed;
	public bool desableColliders = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);
		if (dist < 4f && GameObject.Find("Player").transform.position.z<transform.position.z-distanceZ) {
			transpBed.SetActive (true);
			GetComponent<Renderer> ().enabled = false;
			if (desableColliders) {
				GetComponent<Collider> ().enabled = false;
			}
		} else {
			transpBed.SetActive (false);
			GetComponent<Renderer> ().enabled = true;
			if (desableColliders) {
				GetComponent<Collider> ().enabled = true;
			}
		}
	}
}
