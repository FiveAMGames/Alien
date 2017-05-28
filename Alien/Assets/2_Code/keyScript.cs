using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class keyScript : MonoBehaviour {
	public GameObject grenze;
	public GameObject whereToParent;
	public GameObject forAnimetion;
	public GameObject joint;
	public bool inHand = false;
	private bool onDragging = false;
	public Camera cameraBed;
	public GameObject animationParent;
	public GameObject interactionObject;

	public Texture2D interaction;
	public Texture2D  normal;
	public Texture2D  item;
	public Texture2D  alpha;

	public CursorMode cursorMode = CursorMode.ForceSoftware;
	public Vector2 hotspot = Vector2.zero;

	private bool seeInteraction;
	private Vector3 originalSize;

	private float timer = 0f;

	public float distanceFromPlayerZ = 0.4f;

	// Use this for initialization
	void Start () {
		originalSize = transform.localScale;
		joint = GameObject.Find ("Joint");
		Cursor.SetCursor (alpha, hotspot, CursorMode.ForceSoftware);
		//Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (onDragging) {
			timer++;
			GetComponent<Rigidbody> ().interpolation = RigidbodyInterpolation.Interpolate;
			Cursor.SetCursor (alpha, hotspot, CursorMode.ForceSoftware);


			DragItem ();
			GetComponent<Rigidbody> ().drag = 20f;

			RaycastHit hit;

			Ray ray = new Ray (cameraBed.transform.position, transform.position - cameraBed.transform.position);  //nicht camera, object!


			if (Physics.Raycast (ray, out hit, Mathf.Infinity, 1 << 8)) {

				transform.localScale = new Vector3 (originalSize.x + 0.05f * Mathf.Sin (Time.time * 15f), originalSize.y + 0.05f * Mathf.Sin (Time.time * 15f), originalSize.z + 0.05f * Mathf.Sin (Time.time * 15f));




			
			} else {
			transform.localScale = originalSize;
			}
			if (Input.GetMouseButtonDown (0) && timer > 2f) {
				Cursor.SetCursor (normal, hotspot, CursorMode.ForceSoftware);
				DropItem ();
				forAnimetion.SendMessage ("Dropped");
			}
		}



	}

	void OnMouseEnter(){
		Cursor.SetCursor (item, hotspot, CursorMode.ForceSoftware);
	}

	void OnMouseExit(){
		Cursor.SetCursor (normal, Vector2.zero, CursorMode.ForceSoftware);
	}




	void OnMouseDown(){
		if (!inHand) {
			GetComponent<Collider> ().isTrigger = true;
			GetComponent<Rigidbody> ().isKinematic = true;
			forAnimetion.SendMessage ("KeyInHand");
			transform.SetParent (whereToParent.transform);
			transform.position = whereToParent.transform.position;

			transform.rotation = whereToParent.transform.rotation;
			timer = 0f;
			inHand = true;
		} else {
			Cursor.SetCursor (null, hotspot, CursorMode.ForceSoftware);
			transform.parent = null;
			GetComponent<Collider> ().isTrigger = false;
			GetComponent<Rigidbody> ().isKinematic = false;
			onDragging = true;
			grenze.SetActive (true);
			forAnimetion.SendMessage ("DropOrInteract");
			GetComponent<SphereCollider> ().enabled = false;
			//GetComponent<LookAtCamera> ().enabled = true;

		
		}
	}
	void DropItem(){
		if (onDragging) {
			
				print ("In dropItem methode");
				transform.parent = null;
				onDragging = false;
				inHand = false;
				joint.GetComponent<SpringJoint> ().connectedBody = null;
				GetComponent<Rigidbody> ().drag = 2f;
				//transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
				GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
				GetComponent<Rigidbody> ().isKinematic = false;
				GetComponent<Collider> ().isTrigger = false;

			grenze.SetActive (false);
			GetComponent<SphereCollider> ().enabled = true;
		
			
		}
	}

	void DragItem(){
		Cursor.visible = false;
		transform.rotation =  Quaternion.Euler(180f, 0f, 0f);




		Vector3 globalPlayerTransform = forAnimetion.transform.TransformDirection (GameObject.Find ("Player").transform.position);
		float newZ = globalPlayerTransform.z;

		Vector3 temp = Input.mousePosition;


		float characterZ = forAnimetion.transform.position.z;   //distance from camera

		float distance = cameraBed.transform.position.z - characterZ;



		joint.GetComponent<SpringJoint> ().connectedBody = this.gameObject.GetComponent<Rigidbody> ();

		joint.transform.position = cameraBed.ScreenToWorldPoint (new Vector3 (temp.x, temp.y, distance));
		joint.transform.position = new Vector3 (joint.transform.position.x, joint.transform.position.y, characterZ+distanceFromPlayerZ);






		

		//if (joint.transform.position.y < playerPos.y - 1f) {
		//	joint.transform.position = new Vector3 (joint.transform.position.x, playerPos.y - 1f, joint.transform.position.z);     //to prevent collision with a floor
		//}
		Interaction ();

	}
	void Interaction(){
		RaycastHit hit;

		Ray ray = new Ray (cameraBed.transform.position, transform.position - cameraBed.transform.position);  //nicht camera, object!


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
