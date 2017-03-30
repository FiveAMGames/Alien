using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera: MonoBehaviour {


	
	// Update is called once per frame
	void LateUpdate () {
		transform.LookAt (Camera.main.transform);
		//transform.rotation = Camera.main.transform.rotation;
		//transform.Rotate (0, 180f, 0, Space.World);
	}
}
