using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHandColliderScript : MonoBehaviour {
	public GameObject item;
	public bool inHand = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown (){
		
		if (inHand) {
			item.transform.parent = null;
			item.GetComponent<MyItem> ().onDragging = true;
			item.GetComponent<Collider> ().isTrigger = false;
			item.GetComponent<Rigidbody> ().isKinematic = false;
		}
	}

}
