using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour {

	public GameObject whereToParent;
	public GameObject forAnimetion;
	public GameObject joint;
	private bool inHand = false;
	private bool onDragging = false;
	public Camera cameraBed;
	public GameObject animationParent;
	public GameObject interactionObject;
	// Use this for initialization
	void Start () {
		joint = GameObject.Find ("Joint");
	}
	
	// Update is called once per frame
	void Update () {
		if (onDragging) {

			GetComponent<Rigidbody> ().interpolation = RigidbodyInterpolation.Interpolate;
			Cursor.visible = false;
			DragItem ();
			GetComponent<Rigidbody> ().drag = 20f;
		}




	}
	void OnMouseDown(){
		if (!inHand) {
			forAnimetion.GetComponent<Animator> ().SetBool ("Key", true);
			transform.SetParent (whereToParent.transform);
			transform.position = whereToParent.transform.position;
			transform.rotation = whereToParent.transform.rotation;

			inHand = true;
		} else {
		
			transform.parent = null;
			GetComponent<Collider> ().isTrigger = false;
			GetComponent<Rigidbody> ().isKinematic = false;
			onDragging = true;

		
		}
	}
	void DragItem(){

		transform.rotation =  Quaternion.Euler(180f, 0f, 0f);




		Vector3 globalPlayerTransform = forAnimetion.transform.TransformDirection (GameObject.Find ("Player").transform.position);
		float newZ = globalPlayerTransform.z;

		Vector3 temp = Input.mousePosition;


		float characterZ = forAnimetion.transform.position.z;   //distance from camera

		float distance = cameraBed.transform.position.z - characterZ;



		joint.GetComponent<SpringJoint> ().connectedBody = this.gameObject.GetComponent<Rigidbody> ();

		joint.transform.position = cameraBed.ScreenToWorldPoint (new Vector3 (temp.x, temp.y, distance));
		joint.transform.position = new Vector3 (joint.transform.position.x, joint.transform.position.y, characterZ+0.4f);






		

		//if (joint.transform.position.y < playerPos.y - 1f) {
		//	joint.transform.position = new Vector3 (joint.transform.position.x, playerPos.y - 1f, joint.transform.position.z);     //to prevent collision with a floor
		//}
		Interaction ();

	}
	void Interaction(){
		RaycastHit hit;

		Ray ray = new Ray (Camera.main.transform.position, transform.position - Camera.main.transform.position);  //nicht camera, object!


		if (Physics.Raycast (ray, out hit, Mathf.Infinity, 1 << 8)) {
			if (hit.collider.gameObject == interactionObject) {
				if (Input.GetMouseButtonDown (0)) {
					animationParent.GetComponentInChildren<MeshRenderer> ().enabled = true;


					interactionObject.GetComponent<Animator> ().SetBool ("Open", true);
					onDragging = false;
					joint.GetComponent<SpringJoint> ().connectedBody = null;
					Destroy (gameObject);

				}
			}
		}
	}
}
