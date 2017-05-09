using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		transform.LookAt (target.transform);
		//transform.rotation = Camera.main.transform.rotation;
		//transform.Rotate (0, 180f, 0, Space.World);
	}
}
