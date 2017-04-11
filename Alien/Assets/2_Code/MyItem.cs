using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent (typeof(Collider))]
[RequireComponent (typeof(Rigidbody))]




public class MyItem : MonoBehaviour
{
	


	public bool matthewProperty = false;


	public bool interaction = false;

	public bool onDragging = false;

	public bool inInventory = false;

	public MyInventory inventory;

	GameObject player;

	GameObject walls;

	GameObject collisionObject;

	private GameObject interactionObject;

	public GameObject joint;



	private bool mouseOutOfTheRange = false;
	float dist;


	public void Awake ()
	{
		inventory = GameObject.Find ("Game").GetComponent<MyInventory> ();
		//sets tag of gameobject
		gameObject.tag = "Item";


		if (GetComponent<Transporent> () == null) {
			foreach (Transform child in transform) {
				child.gameObject.AddComponent<Transporent> ();
			}
		}
	}


	// Use this for initialization
	void Start ()
	{
		joint = GameObject.Find ("Joint");

	}
	
	// Update is called once per frame
	void Update ()
	{
		/*if (Input.GetMouseButtonDown (0)) {
			MouseClick ();
		}*/
		
		if (!matthewProperty) {
			dist = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);




			if (onDragging) {
				
				GetComponent<Rigidbody> ().interpolation = RigidbodyInterpolation.Interpolate;
				Cursor.visible = false;
				DragItem ();
				GetComponent<Rigidbody>().drag = 20f;

			
				DropItemMouseOutOfRange ();

				if (Input.GetMouseButtonDown (0) && interactionObject != null) {
					Debug.Log ("I am clicking");

					Debug.Log ("On Drag and click");
					//interactionObject = hit.collider.gameObject;
					interactionObject.SendMessage ("Go");






				}

			}





			if (!onDragging) {
				Cursor.visible = true;
				GetComponent<Rigidbody> ().interpolation = RigidbodyInterpolation.None;
			}

			/*if (Input.GetMouseButtonDown (0)) {
				MouseClick ();
			}*/

		}
	}
	void DragItem(){
		
		transform.rotation = Quaternion.identity;

		



		Vector3 globalPlayerTransform = GameObject.Find ("Player").transform.TransformDirection (GameObject.Find ("Player").transform.position);
		float newZ = globalPlayerTransform.z;

		Vector3 temp = Input.mousePosition;


		float characterZ = GameObject.Find ("Player").transform.position.z;   //distance from camera

		float distance = Camera.main.transform.position.z - characterZ;

	

		joint.GetComponent<SpringJoint> ().connectedBody = this.gameObject.GetComponent<Rigidbody> ();

		joint.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (temp.x, temp.y, distance));
		joint.transform.position = new Vector3 (joint.transform.position.x, joint.transform.position.y, characterZ+0.6f);



		Vector3 playerPos = GameObject.Find ("Player").transform.position;
		Vector3 dplayer = joint.transform.position - playerPos;    //vector from player to object position
		if (dplayer.magnitude > 1.5f) {     						//TODO  or not todo
			joint.transform.position = playerPos + dplayer.normalized * 1.5f;

			mouseOutOfTheRange = true;
			//normalized = norm length to one; 
		} else {
			mouseOutOfTheRange = false;
		}

		//if (joint.transform.position.y < playerPos.y - 1f) {
		//	joint.transform.position = new Vector3 (joint.transform.position.x, playerPos.y - 1f, joint.transform.position.z);     //to prevent collision with a floor
		//}
		Interaction ();

	}

	void Interaction(){
		RaycastHit hit;

		Ray ray = new Ray (Camera.main.transform.position, transform.position - Camera.main.transform.position);  //nicht camera, object!
		  

		if (Physics.Raycast (ray, out hit, Mathf.Infinity, 1 << 8)) {
			
			if (hit.collider.GetComponent<InteractionScript> () != null) {
				if (hit.collider.GetComponent<InteractionScript> ().CheckIfInteractable (gameObject.name) == true) {  //TODO Null reference...only on the edge of cube
				

					Vector3 distToInteraction = transform.position - hit.transform.position;
					//print (distToInteraction);
					if (distToInteraction.magnitude < 2f) {
						interactionObject = hit.collider.gameObject;

						Debug.Log ("I see interaction object with Raycast");

					}
				}
			}

		} else { 

			if (interactionObject != null) {
				interactionObject = null;
				Debug.Log ("Some message");
			}


		}
	}

	void DropItemMouseOutOfRange(){
		if (Input.GetMouseButtonDown (0) && mouseOutOfTheRange && interactionObject == null) { //to drop items, also out of the cursir range
			onDragging = false;
			joint.GetComponent<SpringJoint> ().connectedBody = null;
			GetComponent<Rigidbody>().drag = 0f;
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			GetComponent<Rigidbody> ().isKinematic = false;
			GetComponent<Collider> ().isTrigger = false;
			inventory.removeItem (this);
		}
	}

	void BackInHand(){
		if (Input.GetMouseButtonDown (1)) {
			onDragging = false;
			joint.GetComponent<SpringJoint> ().connectedBody = null;
			GetComponent<Rigidbody>().drag = 0f;
			//GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			inventory.backInHand (this);
		} 
	
	}

	/*void MouseClick(){
		RaycastHit hit;

		Ray ray = new Ray (Camera.main.transform.position, transform.position - Camera.main.transform.position);


		if (Physics.Raycast (ray, out hit, Mathf.Infinity, 1 << 9)) {

			Vector3 distToObj = GameObject.Find ("Player").transform.position - transform.position;

			if (hit.collider.gameObject == this.gameObject && (distToObj.magnitude < 2f)) {
	
				if (!matthewProperty) {

					if (onDragging) {

						if (interactionObject == null) {
							print ("no interaction object, drop");
							onDragging = false;
							joint.GetComponent<SpringJoint> ().connectedBody = null;
							GetComponent<Rigidbody> ().drag = 0f;
							GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
							GetComponent<Rigidbody> ().isKinematic = false;
							GetComponent<Collider> ().isTrigger = false;
							inventory.removeItem (this);
						} else {
							print ("has an interaction object!");
						}
						return;
					}



					if (dist < 3f) {

						if (!inInventory) {  

							//place in inventory
							GetComponent<Rigidbody> ().isKinematic = true;
							inventory.addItem (this);
						} else {  
							//if it's already in inventory
							if (!onDragging) {
								GetComponentInParent<SoundScript> ().PlayTakeItemFromInventory ();//if not on drag - drag it
								transform.parent = null;
								onDragging = true;


								GetComponent<Collider> ().isTrigger = false;
								GetComponent<Rigidbody> ().isKinematic = false;

							}
						}	
					}

				}
			}
		}

	}*/




	void OnMouseDown ()
	{
		if (!matthewProperty) {

			if (onDragging) {

				if (interactionObject == null) {
					print ("no interaction object, drop");
					onDragging = false;
					joint.GetComponent<SpringJoint> ().connectedBody = null;
					GetComponent<Rigidbody> ().drag = 0f;
					GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
					GetComponent<Rigidbody> ().isKinematic = false;
					GetComponent<Collider> ().isTrigger = false;
					inventory.removeItem (this);
				} else {
					print ("has an interaction object!");
				}
				return;
			}



			if (dist<3f){
				
			if (!inInventory ) {  
				
				//place in inventory
				GetComponent<Rigidbody> ().isKinematic = true;
				inventory.addItem (this);
			} else {  
					//if it's already in inventory
					if (!onDragging) {
						GetComponentInParent<SoundScript> ().PlayTakeItemFromInventory ();//if not on drag - drag it
						transform.parent = null;
						onDragging = true;


						GetComponent<Collider> ().isTrigger = false;
						GetComponent<Rigidbody> ().isKinematic = false;
				
					}
				}	
			}
	
	}
	}



	 void OnCollisionEnter(Collision coll){
		if (!onDragging) {
			//GetComponent<Rigidbody> ().isKinematic = true;
		}
		if (coll.gameObject.CompareTag("Ground")){
			GetComponent<AudioSource> ().Play ();
			//GetComponent<Rigidbody> ().isKinematic = true;
		}

	}




	void OnTriggerEnter(Collider coll){
		collisionObject = coll.gameObject;
		if (coll.gameObject.CompareTag ("Wall")) { 
			if (onDragging) {
				//walls = coll.gameObject;
				print ("I see the wall(");
			//	transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
			}
		}
	}

	void OnTriggerExit(Collider coll){
		collisionObject = null;
		/*if (coll.gameObject.CompareTag ("Wall")) {
			if (onDragging) {
				walls = null;
			}
		}*/
	}
}
//Предметы в руке проходят