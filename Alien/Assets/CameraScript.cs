using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject player;
	private float startpositionZ;
	// Use this for initialization
	void Start () {
		startpositionZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);
		if (Input.GetAxis ("Mouse ScrollWheel") > 0f) {
			transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z-1f*Time.deltaTime*10f);
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0f) {
			transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z+1f*Time.deltaTime*10f);
		}
		if (Input.GetMouseButtonDown(2)) {
			transform.position = new Vector3 (player.transform.position.x, transform.position.y, startpositionZ);
		}
		transform.LookAt (player.transform);
	}
}
