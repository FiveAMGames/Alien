using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject player;
	private float startpositionZ;
	private bool check = false;
	public Transform posY;
	public bool startCamera = true;
	public bool cutScene= false;
	public bool fromCutScene = false;
	public bool hammerScene = false;
	// Use this for initialization
	void Start () { 
		startpositionZ = transform.position.z;
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (hammerScene) {
			
				transform.position = new Vector3 (-12.68f, -0.5f, 11.68f);

		}

		if (cutScene && transform.position.x > -12f && !fromCutScene ) {
			transform.position = new Vector3 (transform.position.x - 2f * Time.deltaTime, transform.position.y, transform.position.z);
		}

		if (fromCutScene) {
			if (transform.position.x < player.transform.position.x) {
				transform.position = new Vector3 (transform.position.x + 2f * Time.deltaTime, transform.position.y, transform.position.z);
			} else {
				cutScene = false;
				fromCutScene = false;
			}
		}

		if (!startCamera && !cutScene && !hammerScene){ 
			transform.position = new Vector3 (player.transform.position.x, posY.position.y, transform.position.z);
			//print(player.transform.position.y);
			if (player.transform.position.y > 0f) {
				if (Vector3.Distance (transform.position, player.transform.position) >= 5f) {
			
					transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z - 1.2f * Time.deltaTime);

				}
				//if (Vector3.Distance (transform.position, player.transform.position) <= 3f) {
				if (transform.position.z - player.transform.position.z < 5f) {
			
					transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z + 1.2f * Time.deltaTime);

				}
				if (Input.GetAxis ("Mouse ScrollWheel") > 0f) {
					transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z - 1f * Time.deltaTime * 10f);
				}
				if (Input.GetAxis ("Mouse ScrollWheel") < 0f) {
					transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z + 1f * Time.deltaTime * 10f);
				}
				if (Input.GetMouseButtonDown (2)) {
					transform.position = new Vector3 (player.transform.position.x, transform.position.y, startpositionZ);
				}
				transform.LookAt (player.transform);
			}
			if (player.transform.position.y <= 0f) {
			
				if (Vector3.Distance (transform.position, player.transform.position) >= 10f) {

					transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z - 1.2f * Time.deltaTime);

				}
				//if (Vector3.Distance (transform.position, player.transform.position) <= 3f) {
				if (transform.position.z - player.transform.position.z <= 6f) {

					transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z + 1.2f * Time.deltaTime);

				}
				if (Input.GetAxis ("Mouse ScrollWheel") > 0f) {
					transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z - 1f * Time.deltaTime * 10f);
				}
				if (Input.GetAxis ("Mouse ScrollWheel") < 0f) {
					transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z + 1f * Time.deltaTime * 10f);
				}
				if (Input.GetMouseButtonDown (2)) {
					transform.position = new Vector3 (player.transform.position.x, transform.position.y, startpositionZ);
				}
				transform.LookAt (player.transform);
			}
		}

	}
	/*void LateUpdate(){
		if (Vector3.Distance (transform.position, player.transform.position) >= 5f) {

			transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z-0.1f);

		}
		if (Vector3.Distance (transform.position, player.transform.position) <= 3f) {

			transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z+0.1f);

		}
	}*/
}
